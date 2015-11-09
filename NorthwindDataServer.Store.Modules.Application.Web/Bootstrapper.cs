using Autofac;
using NorthwindDataServer.Store.Modules.Application.Web.Controllers;

namespace NorthwindDataServer.Store.Modules.Application.Web
{
    public static class Bootstrapper
    {
        public static IContainer Container { get; private set; }

        public static IContainer Initialize()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<BaseController>().InstancePerRequest();
            builder.RegisterType<AuthenticationController>().InstancePerRequest();
            builder.RegisterType<WebApplicationConfiguration>().SingleInstance();

            Container = builder.Build();

            return Container;
        }

    }
}