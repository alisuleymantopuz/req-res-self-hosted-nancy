using Autofac;
using FluentAssertions;
using Nancy;
using Nancy.Authentication.Token;
using Nancy.Authentication.Token.Storage;
using Nancy.Testing.Fakes;
using NorthwindDataServer.Store.Modules.Models;
using NUnit.Framework;
using System.IO;
using System.Net;
using System.Text;
using HttpStatusCode = Nancy.HttpStatusCode;

namespace NorthwindDataServer.Store.Modules.Application.Tests
{
    using Nancy.Testing;
    using System;

    [TestFixture]
    public class AuthModuleFixture
    {
        private readonly Browser _browser;

        public AuthModuleFixture()
        {
            var bootstrapper = new TestBootstrapper();

            this._browser = new Browser(bootstrapper);
        }

        [Test]
        public void Should_return_generated_token_for_valid_user_credentials()
        {
            // Given, When
            var response = this._browser.Post("/auth/", (with) =>
            {
                with.HttpRequest();
                with.Accept("application/json");
                with.Header("User-Agent", "Nancy Browser");
                with.FormValue("UserName", "atopuz");
                with.FormValue("Password", "1234567");
            });

            // Then
            var authResponse = response.Body.DeserializeJson<AuthResponse>();

            authResponse.Should().NotBeNull();
        }

        [Test]
        public void Should_return_unauthorized_for_invalid_user_credentials()
        {
            // Given, When
            var response = this._browser.Post("/auth/", (with) =>
            {
                with.HttpRequest();
                with.Accept("application/json");
                with.Header("User-Agent", "Nancy Browser");
                with.FormValue("UserName", "test");
                with.FormValue("Password", "test");
            });

            // Then
            response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
        }

        [Test]
        public void Should_return_unauthorized_when_not_authenticated()
        {
            // Given, When
            var response = this._browser.Get("/auth/admin/", (with) =>
            {
                with.HttpRequest();
            });

            // Then
            response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
        }

        [Test]
        public void Should_return_ok_when_authorized()
        {
            // Given, When
            var response = this._browser.Post("/auth/", (with) =>
            {
                with.HttpRequest();
                with.Accept("application/json");
                with.Header("User-Agent", "Nancy Browser");
                with.FormValue("UserName", "atopuz");
                with.FormValue("Password", "1234567");
            });

            var token = response.Body.DeserializeJson<AuthResponse>().Token;

            var secondResponse = response.Then.Get("/auth/admin/", with =>
            {
                with.HttpRequest();
                with.Header("User-Agent", "Nancy Browser");
                with.Header("Authorization", "Token " + token);
            });

            // Then
            secondResponse.StatusCode.Should().Be(HttpStatusCode.OK);
        }
        
        
        [Test]
        public void Should_return_ok_for_valid_user_credentials_from_web_request()
        {
            var parameters = new
            {
                userName ="atopuz",
                password = "1234567"
            };

            var request = (HttpWebRequest)WebRequest.Create("http://127.0.0.1:5557/auth/");
            request.Method = "POST";
            var postBytes = Encoding.UTF8.GetBytes(System.Web.Helpers.Json.Encode(parameters));
            request.ContentType = "application/json; charset=UTF-8";
            request.Accept = "application/json";
            request.ContentLength = postBytes.Length;
            request.UserAgent = "Web Application Test";
            var requestStream = request.GetRequestStream();
            requestStream.Write(postBytes, 0, postBytes.Length);
            requestStream.Close();
            var response = (HttpWebResponse)request.GetResponse();
            string result;

            using (var rdr = new StreamReader(response.GetResponseStream()))
                result = rdr.ReadToEnd();
        }
    }

    public class AuthResponse
    {
        public string Token { get; set; }
    }

    public class TestBootstrapper : NancyBootstrapper
    {
        protected override void ConfigureApplicationContainer(ILifetimeScope existingContainer)
        {
            var containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterInstance(new Tokenizer(cfg => cfg.WithKeyCache(new InMemoryTokenKeyStore()))).As<ITokenizer>();

            containerBuilder.RegisterType<UserIdentityProvider>().As<IUserIdentityProvider>().SingleInstance();

            containerBuilder.Update(existingContainer.ComponentRegistry);

            this.ApplicationContainerConfigured = true;
        }


        protected override IRootPathProvider RootPathProvider
        {
            get
            {
                var assemblyFilePath =
                    new Uri(typeof(NancyBootstrapper).Assembly.CodeBase).LocalPath;

                var assemblyPath =
                    Path.GetDirectoryName(assemblyFilePath);

                var rootPath =
                    PathHelper.GetParent(assemblyPath, 2);

                FakeRootPathProvider.RootPath = rootPath;

                //FakeRootPathProvider.RootPath = @"C:\Users\a.topuz\Documents\Visual Studio 2013\Projects\NorthwindDataServer\NorthwindDataServer.Store.Modules.Application\bin\Debug";

                return new FakeRootPathProvider();

            }
        }
    }
}
