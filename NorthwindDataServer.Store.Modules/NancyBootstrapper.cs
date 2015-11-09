using Autofac;
using Nancy;
using Nancy.Authentication.Token;
using Nancy.Bootstrapper;
using Nancy.Bootstrappers.Autofac;
using NorthwindDataServer.Domain.Authentication;
using NorthwindDataServer.Domain.Common;
using NorthwindDataServer.Domain.Store;
using NorthwindDataServer.Orm.Common;
using NorthwindDataServer.Store.Modules.Assemblers;
using NorthwindDataServer.Store.Modules.Managers;
using NorthwindDataServer.Store.Modules.Models;
using NorthwindDataServer.Store.Modules.ServiceDefinitions;

namespace NorthwindDataServer.Store.Modules
{
    public class NancyBootstrapper : AutofacNancyBootstrapper
    {
        public bool RequestContainerConfigured { get; set; }

        public bool ApplicationContainerConfigured { get; set; }

        private readonly NancyInternalConfiguration _configuration;

        public NancyBootstrapper()
        {

        }

        public NancyBootstrapper(NancyInternalConfiguration configuration)
        {
            this._configuration = configuration;
        }

        protected override NancyInternalConfiguration InternalConfiguration
        {
            get { return _configuration ?? base.InternalConfiguration; }
        }

        protected override void ConfigureRequestContainer(ILifetimeScope container, NancyContext context)
        {
            base.ConfigureRequestContainer(container, context);

            var containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterInstance(new NorthwindDataServerCommonEntities())
                .SingleInstance();

            containerBuilder.RegisterInstance(new StoreServiceApplicationConfiguration())
                .SingleInstance();

            #region ResponseCode Registrations

            containerBuilder.RegisterType<ResponseCodeRepository>().As<IResponseCodeRepository>()
                .InstancePerLifetimeScope();

            containerBuilder.RegisterType<ResponseCodeManager>().As<IResponseCodeManager>()
                .InstancePerLifetimeScope();

            containerBuilder.RegisterType<ResponseValueModuleAssembler>().As<IResponseValueModuleAssembler>()
                .InstancePerLifetimeScope();

            containerBuilder.RegisterType<ResponseValueModule>().As<IResponseValueModule>()
                .InstancePerLifetimeScope();

            #endregion

            #region Authentication Registrations

            containerBuilder.RegisterType<UserRepository>().As<IUserRepository>()
                .InstancePerLifetimeScope();

            containerBuilder.RegisterType<UserManager>().As<IUserManager>()
                .InstancePerLifetimeScope();

            containerBuilder.RegisterType<AuthenticationModuleAssembler>().As<IAuthenticationModuleAssembler>()
                .InstancePerLifetimeScope();

            containerBuilder.RegisterType<AuthModule>().As<IAuthModule>()
                .InstancePerLifetimeScope();

            #endregion

            #region Product Registrations

            containerBuilder.RegisterType<ProductRepository>().As<IProductRepository>()
                .InstancePerLifetimeScope();

            containerBuilder.RegisterType<ProductManager>().As<IProductManager>()
                .InstancePerLifetimeScope();

            containerBuilder.RegisterType<ProductModuleAssembler>().As<IProductModuleAssembler>()
                .InstancePerLifetimeScope();

            containerBuilder.RegisterType<ProductModule>().As<IProductModule>()
                .InstancePerLifetimeScope();

            #endregion

            containerBuilder.Update(container.ComponentRegistry);

            this.RequestContainerConfigured = true;
        }

        protected override void ConfigureApplicationContainer(ILifetimeScope existingContainer)
        {
            var containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterInstance(new Tokenizer()).As<ITokenizer>();

            containerBuilder.RegisterType<UserIdentityProvider>().As<IUserIdentityProvider>().SingleInstance();

            containerBuilder.Update(existingContainer.ComponentRegistry);

            this.ApplicationContainerConfigured = true;
        }

        protected override void RequestStartup(ILifetimeScope container, IPipelines pipelines, NancyContext context)
        {
            pipelines.BeforeRequest.AddItemToEndOfPipeline(ctx =>
            {
                container.Resolve<IUserIdentityProvider>().CurrentUser = ctx.CurrentUser;
                return null;
            });

            TokenAuthentication.Enable(pipelines, new TokenAuthenticationConfiguration(container.Resolve<ITokenizer>()));
        }

        public T Resolve<T>()
        {
            return this.ApplicationContainer.Resolve<T>();
        }

    }
}
