using AnimeDb.Client.Configurations.Attributes;
using AnimeDb.Client.Configurations.Handlers;
using AnimeDb.Client.Configurations.Handlers.Middlewares;
using AnimeDb.Client.Configurations.Handlers.QueryParsers;
using AnimeDb.Client.Services.AnimeRepositories;
using AnimeDb.Client.Services.CatalogServive;
using AnimeDb.Client.Services.QueryBuilderService;
using AnimeDb.Client.ViewModels.Catalog;
using AnimeDb.Client.ViewModels.Viewer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace AnimeDb.Client.Configurations
{
    public static class StartupApp
    {
        public static IServiceProvider Configure()
        {
            IServiceCollection services = new ServiceCollection();

            //System
            services.AddSingleton(CreateConfiguration);
            services.AddTransient<IParameterParser, ParameterParser>();

            services.AddTransient<IMiddleware, DataContextUseHandler>();

            //ViewModel
            services.AddTransient<CatalogViewModel>();
            services.AddTransient<LoaderCommand>();
            services.AddTransient<LastPageCommand>();
            services.AddTransient<NextPageCommand>();
            services.AddTransient<ReloadPageCommand>();
            services.AddTransient<SearchCommand>();

            services.AddTransient<ViewerViewModel>();

            //Services
            services.AddTransient<IAnimeRepository, AnimeRepository>();
            services.AddTransient<ICatalogService, Catalog>();
            services.AddTransient<IQueryBuilder, QueryBuilder>();

            return services.BuildServiceProvider();
        }

        private static IConfiguration CreateConfiguration(IServiceProvider service)
        {
            return new ConfigurationBuilder()
                            .SetBasePath(Environment.CurrentDirectory)
                            .AddJsonFile("appsettings.json")
                            .Build();
        }

    }
}
