using Nancy.Security;
using NorthwindDataServer.Orm.Common;

namespace NorthwindDataServer.Store.Modules.Managers
{
    public interface IUserManager
    {
        IUserIdentity ValidateUser(string userName, string password);

        User GetUserByUserName(string userName);
    }
}
