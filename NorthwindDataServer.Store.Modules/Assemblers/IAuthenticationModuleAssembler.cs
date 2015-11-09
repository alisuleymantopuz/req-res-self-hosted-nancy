using Nancy.Security;
using NorthwindDataServer.Orm.Common;
using NorthwindDataServer.Store.Modules.Contracts;

namespace NorthwindDataServer.Store.Modules.Assemblers
{
    public interface IAuthenticationModuleAssembler
    {
        CheckUserResponse ToCheckUserResponse(User user);

        CheckUserResponse ToCheckUserResponse(IUserIdentity user);
    }
}
