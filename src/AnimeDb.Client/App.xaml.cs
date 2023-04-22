using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;
using AnimeDb.Client.Configurations;
using System.Reflection;
using AnimeDb.Client.Configurations.Handlers;
using AnimeDb.Client.Configurations.Handlers.QueryParsers;

namespace AnimeDb.Client
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IServiceProvider _serviceProvider;

        public App()
        {
            _serviceProvider = StartupApp.Configure();
        }

        protected override void OnNavigating(NavigatingCancelEventArgs e)
        {
            base.OnNavigating(e);
        }

        protected override void OnNavigated(NavigationEventArgs e)
        {
            using (IServiceScope scope = _serviceProvider.CreateScope())
            {
                var data = e.Content;
                var query = e.Uri.OriginalString;

                IParameterParser parser = _serviceProvider.GetRequiredService<IParameterParser>();
                IDictionary<string, object> parameters = parser.Parse(query);

                IEnumerable<IMiddleware> middlewares = _serviceProvider.GetRequiredService<IEnumerable<IMiddleware>>();
                foreach (var middleware in middlewares)
                    middleware.Handle(data, parameters);

                base.OnNavigated(e);
            }
        }

    }
}
