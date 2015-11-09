using NorthwindDataServer.Infastructure.Repository;
using NorthwindDataServer.Orm.Common;

namespace NorthwindDataServer.Domain.Common
{
    public interface IResponseCodeRepository : IRepository<ResponseCode>
    {
        Language LanguageGetByCode(string code);
    }
}
