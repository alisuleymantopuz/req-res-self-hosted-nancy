using Nancy.Security;

namespace NorthwindDataServer.Store.Modules.Models
{
    public interface IUserIdentityProvider
    {
        IUserIdentity CurrentUser { get; set; }
    }
}
