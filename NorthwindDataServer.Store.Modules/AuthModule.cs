using Nancy;
using Nancy.Authentication.Token;
using Nancy.Security;
using NorthwindDataServer.Infastructure.Extensions;
using NorthwindDataServer.Store.Modules.Assemblers;
using NorthwindDataServer.Store.Modules.Contracts;
using NorthwindDataServer.Store.Modules.Managers;
using NorthwindDataServer.Store.Modules.Models;
using NorthwindDataServer.Store.Modules.ServiceDefinitions;
using System;
using System.Linq;

namespace NorthwindDataServer.Store.Modules
{
    public class AuthModule : NancyModule, IAuthModule
    {
        public IUserManager UserManager { get; private set; }

        public ITokenizer Tokenizer { get; private set; }

        public IAuthenticationModuleAssembler AuthenticationRoutesAssembler { get; private set; }

        public IUserIdentityProvider UserIdentityProvider { get; private set; }

        public AuthModule(ITokenizer tokenizer, IUserManager userManager, IAuthenticationModuleAssembler authenticationRoutesAssembler, IUserIdentityProvider userIdentityProvider)
            : base("/auth")
        {
            UserIdentityProvider = userIdentityProvider;
            AuthenticationRoutesAssembler = authenticationRoutesAssembler;

            UserManager = userManager;

            Tokenizer = tokenizer;

            Post["/"] = Authenticate;

            Get["/admin"] = Administration;

            Get["/checkUser/{UserNameAndPassword}"] = CheckUser;
        }

        public dynamic Authenticate(dynamic parameters)
        {
            try
            {
                var userName = (string)this.Request.Form.UserName;

                var password = (string)this.Request.Form.Password;

                var userIdentity = UserManager.ValidateUser(userName, password);

                if (userIdentity == null || !userIdentity.Claims.Any())
                {
                    return HttpStatusCode.Unauthorized;
                }

                var token = Tokenizer.Tokenize(userIdentity, Context); 

                return Response.AsJson(new
                {
                    Token = token,
                });
            }
            catch (Exception)
            {
                return HttpStatusCode.InternalServerError;
            }

        }

        public dynamic CheckUser(dynamic parameters)
        {
            string encodedUsernameAndPassword = parameters.UserNameAndPassword;

            var usernameAndPassword = encodedUsernameAndPassword.Base64Decode();

            var userInfoValues = usernameAndPassword.Split(':');

            if (!userInfoValues.Any())
                return Response.AsJson(new CheckUserResponse() { IsUserExist = false });

            var user = UserManager.ValidateUser(userInfoValues[0], userInfoValues[1]);

            return Response.AsJson(AuthenticationRoutesAssembler.ToCheckUserResponse(user));
        }

        public dynamic Administration(dynamic parameters)
        {
            this.RequiresAuthentication();

            this.RequiresClaims(new string[] { "Admin" });

            return "You are authorized!";
        }
    }
}
