using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using DoggyFoody.Database;
using DoggyFoody.Services;
using System.Reflection;
using System.Web.Http;

namespace DoggyFoody.API
{
    public class DependenciesConfig
    {
        public static void RegisterDependencies(HttpConfiguration config)
        {
            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            RegisterDbContext(builder);
            RegisterServices(builder);
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static void RegisterDbContext(ContainerBuilder builder)
        {
            builder.RegisterType<DoggyFoodyDatabaseContext>().InstancePerLifetimeScope();
        }

        private static void RegisterServices(ContainerBuilder builder)
        {
            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterType<ProductService>().As<IProductService>();
            builder.RegisterType<AdvertisementService>().As<IAdvertisementService>();
            builder.RegisterType<ColumnService>().As<IColumnService>();
            builder.RegisterType<ManufacturerService>().As<IManufacturerService>();

        }
    }
}
