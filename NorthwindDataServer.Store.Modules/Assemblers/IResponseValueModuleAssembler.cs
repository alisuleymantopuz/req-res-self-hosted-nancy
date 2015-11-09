using NorthwindDataServer.Orm.Common;
using NorthwindDataServer.Store.Modules.Contracts;
using System.Collections.Generic;

namespace NorthwindDataServer.Store.Modules.Assemblers
{
    public interface IResponseValueModuleAssembler
    {
        IEnumerable<ResponseCodeInfo> ToResponseCodeInfoCollection(IEnumerable<ResponseCode> responseCodes);

        ResponseCodeInfo ToResponseCodeInfo(ResponseCode responseCode);

        SearchResponseCodeInfoResponse ToSearchResponseCodeInfoResponse(IEnumerable<ResponseCode> responseCodes);

        SearchResponseCodeInfoResponse ToSearchResponseCodeInfoResponse(IEnumerable<ResponseCodeInfo> responseCodes);

        SearchResponseCodeInfoResponse ToSearchResponseCodeInfoResponse(ResponseCode responseCode);

        SearchResponseCodeInfoResponse ToSearchResponseCodeInfoResponse(ResponseCodeInfo responseCodeInfo);

        ResponseCode ToResponseCode(CreateResponseCodeRequest createResponseCodeRequest);

        CreateResponseCodeResponse ToCreateResponseCodeResponse(ResponseCode responseCode);
    }
}
