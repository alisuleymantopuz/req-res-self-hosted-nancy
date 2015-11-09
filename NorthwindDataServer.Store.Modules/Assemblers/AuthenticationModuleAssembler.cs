using Nancy.Security;
using NorthwindDataServer.Domain.Authentication;
using NorthwindDataServer.Orm.Common;
using NorthwindDataServer.Store.Modules.Contracts;

namespace NorthwindDataServer.Store.Modules.Assemblers
{
    public class AuthenticationModuleAssembler : IAuthenticationModuleAssembler
    {
        public IUserRepository UserRepository { get; private set; }

        public AuthenticationModuleAssembler(IUserRepository userRepository)
        {
            UserRepository = userRepository;
        }

        public CheckUserResponse ToCheckUserResponse(User user)
        {
            var checkUserResponse = new CheckUserResponse();
            if (user == null)
            {
                checkUserResponse.IsUserExist = false;
                return checkUserResponse;
            }

            checkUserResponse.IsUserExist = true;
            checkUserResponse.Name = user.Name;
            checkUserResponse.Surname = user.Surname;
            checkUserResponse.Username = user.UserName;

            return checkUserResponse;
        }
        
        public CheckUserResponse ToCheckUserResponse(IUserIdentity user)
        {
            var checkUserResponse = new CheckUserResponse();

            if (user == null)
            {
                checkUserResponse.IsUserExist = false;
                return checkUserResponse;
            }

            var domainUser = this.UserRepository.FirstOrDefault(x => x.UserName == user.UserName);

            checkUserResponse.IsUserExist = true;
            checkUserResponse.Username = domainUser.UserName;
            checkUserResponse.Name = domainUser.Name;
            checkUserResponse.Surname = domainUser.Surname;

            return checkUserResponse;
        }
    }
}
