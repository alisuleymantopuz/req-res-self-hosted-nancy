using Autofac.Integration.Mvc;
using System.Web.Mvc;
using System.Web.Routing;

namespace NorthwindDataServer.Store.Modules.Application.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes); 
            DependencyResolver.SetResolver(new AutofacDependencyResolver(Bootstrapper.Initialize()));
        }
    }
}
