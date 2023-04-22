using AnimeDb.Client.Configurations.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Markup;

namespace AnimeDb.Client.Configurations.Handlers.Middlewares
{
    public class DataContextUseHandler : IMiddleware
    {
        private readonly IServiceProvider _serviceProvider;

        public DataContextUseHandler(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public void Handle(object data, IDictionary<string, object> parameters)
        {
            var type = data.GetType();
            var attribute = type.GetCustomAttribute<DataContextUseAttribute>();

            if (attribute != null && data is Page page)
            {
                var serviceType = attribute.Context;
                var viewModel = _serviceProvider.GetService(serviceType);
                if (viewModel is null)
                    return;

                InjectParametersIntoMethods(viewModel, parameters);
                InjectParametersIntoProperties(viewModel, parameters);
                page.DataContext = viewModel;
            }
        }

        private void InjectParametersIntoMethods(object viewModel, IDictionary<string, object> parameters)
        {
            var type = viewModel.GetType();
            var methods = type.GetMethods();

            foreach (var method in methods)
            {
                var attribute = method.GetCustomAttribute<InjectParameterAttribute>();
                if (attribute == null)
                    continue;

                if (!parameters.ContainsKey(attribute.Key))
                    continue;

                var value = parameters[attribute.Key];
                method.Invoke(viewModel, new object[] { value });
            }
        }

        private void InjectParametersIntoProperties(object viewModel, IDictionary<string, object> parameters)
        {
            var type = viewModel.GetType();
            var properties = type.GetProperties();

            foreach (var property in properties)
            {
                var attribute = property.GetCustomAttribute<InjectParameterAttribute>();
                if (attribute == null)
                    continue;

                if (!parameters.ContainsKey(attribute.Key))
                    continue;

                var value = parameters[attribute.Key];
                property.SetValue(viewModel, value);
            }

        }
    }
}
