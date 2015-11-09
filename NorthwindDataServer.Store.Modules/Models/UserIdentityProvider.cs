using Nancy.Security;

namespace NorthwindDataServer.Store.Modules.Models
{
    public class UserIdentityProvider : IUserIdentityProvider
    {
        public IUserIdentity CurrentUser { get; set; }
    }
}
