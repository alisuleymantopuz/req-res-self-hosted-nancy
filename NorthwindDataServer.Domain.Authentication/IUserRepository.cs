using NorthwindDataServer.Infastructure.Repository;
using NorthwindDataServer.Orm.Common;

namespace NorthwindDataServer.Domain.Authentication
{
    public interface IUserRepository : IRepository<User>
    {
        User CheckUser(string username, string password);
    }
}
