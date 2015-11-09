using Nancy;
using NorthwindDataServer.Store.Modules.Models;
using System;
using System.Linq;

namespace NorthwindDataServer.Store.Modules.Extensions
{
    public static class ModuleSecurityExtensions
    {
        public static Response RequiresAuthentication(this NancyContext context, IUserIdentityProvider userIdentityProvider)
        {
            Response response = null;
            if ((userIdentityProvider.CurrentUser == null) ||
                String.IsNullOrWhiteSpace(userIdentityProvider.CurrentUser.UserName))
            {
                response = new Response { StatusCode = HttpStatusCode.Unauthorized };
            }

            return response;
        }


        public static Response RequiresClaimsAuthentication(this NancyContext context, IUserIdentityProvider userIdentityProvider,string claim)
        {
            Response response = null;
            if ((userIdentityProvider.CurrentUser == null) ||
                (userIdentityProvider.CurrentUser.Claims == null) || 
                (!userIdentityProvider.CurrentUser.Claims.Any()) || 
                (!userIdentityProvider.CurrentUser.Claims.Contains(claim)) ||
                String.IsNullOrWhiteSpace(userIdentityProvider.CurrentUser.UserName))
            {
                response = new Response { StatusCode = HttpStatusCode.Unauthorized };
            }

            return response;
        }
    }
}
