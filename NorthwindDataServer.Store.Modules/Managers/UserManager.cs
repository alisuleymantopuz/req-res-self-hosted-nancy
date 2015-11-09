using Nancy.Security;
using NorthwindDataServer.Domain.Authentication;
using NorthwindDataServer.Orm.Common;
using NorthwindDataServer.Store.Modules.Assemblers;
using NorthwindDataServer.Store.Modules.Models;
using System.Linq;

namespace NorthwindDataServer.Store.Modules.Managers
{
    public class UserManager : IUserManager
    {
        public IUserRepository UserRepository { get; private set; }

        public IAuthenticationModuleAssembler AuthenticationRoutesAssembler { get; private set; }

        public UserManager(IUserRepository userRepository, IAuthenticationModuleAssembler authenticationRoutesAssembler)
        {
            AuthenticationRoutesAssembler = authenticationRoutesAssembler;

            UserRepository = userRepository;
        }

        public IUserIdentity ValidateUser(string userName, string password)
        {
            var user = this.UserRepository.CheckUser(userName, password);

            if (user == null) return null;
            
            var claims = user.UserClaims.Select(x => x.Name).ToList();

            return new UserIdentity() { Claims = claims, UserName = user.UserName };
        }


        public User GetUserByUserName(string userName)
        {
            return UserRepository.FirstOrDefault(x => x.UserName == userName);
        }
    }
}
