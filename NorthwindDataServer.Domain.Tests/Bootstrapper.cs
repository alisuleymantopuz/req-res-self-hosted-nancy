using Autofac;
using NorthwindDataServer.Domain.Common;
using NorthwindDataServer.Orm.Common;

namespace NorthwindDataServer.Domain.Tests
{
    public static class Bootstrapper
    {
        public static IContainer Container { get; set; }

        public static IContainer Initialize()
        {
            var containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterInstance(new NorthwindDataServerCommonEntities()).SingleInstance();
 
            containerBuilder.RegisterType<ResponseCodeRepository>().As<IResponseCodeRepository>().InstancePerLifetimeScope();
 
            Container = containerBuilder.Build();

            return Container;
        }
    }
}
