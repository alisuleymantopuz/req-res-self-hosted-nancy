using NorthwindDataServer.Orm.Common;
using NorthwindDataServer.Store.Modules.Contracts;
using System;
using System.Collections.Generic;

namespace NorthwindDataServer.Store.Modules.Managers
{
    public interface IResponseCodeManager
    {
        IEnumerable<ResponseCodeInfo> AllResponseCodes();

        SearchResponseCodeInfoResponse SearchResponseCodeInfo(SearchProductsRequest searchProductsRequest);

        ResponseCodeInfo FindResponseCodeById(Guid id);

        ResponseCodeInfo FindResponseCodeByCode(string code);

        ResponseCode Create(CreateResponseCodeRequest createResponseCode);
    }
}
