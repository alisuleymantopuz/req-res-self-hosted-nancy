using NorthwindDataServer.Orm.Common;
using NorthwindDataServer.Store.Modules.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace NorthwindDataServer.Store.Modules.Assemblers
{
    public class ResponseValueModuleAssembler : IResponseValueModuleAssembler
    {
        public IEnumerable<ResponseCodeInfo> ToResponseCodeInfoCollection(IEnumerable<ResponseCode> responseCodes)
        {
            IList<ResponseCodeInfo> responseCodeInfos = new List<ResponseCodeInfo>();

            foreach (var responseCode in responseCodes)
            {
                var responseCodeInfo = new ResponseCodeInfo
                {
                    Code = responseCode.Code
                };

                if (responseCode.ResponseCodeDescriptions.Any())
                {
                    responseCodeInfo.ResponseCodeDescriptionInfos = new List<ResponseCodeDescriptionInfo>();
                    foreach (var responseCodeDescription in responseCode.ResponseCodeDescriptions)
                    {
                        responseCodeInfo.ResponseCodeDescriptionInfos.Add(new ResponseCodeDescriptionInfo()
                        {
                            Description = responseCodeDescription.Description,
                            Message = responseCodeDescription.Message,
                            Language = responseCodeDescription.Language.Code,
                        });
                    }
                }

                responseCodeInfos.Add(responseCodeInfo);
            }

            return responseCodeInfos;
        }

        public ResponseCodeInfo ToResponseCodeInfo(ResponseCode responseCode)
        {
            var responseCodeInfo = new ResponseCodeInfo
            {
                Code = responseCode.Code
            };

            if (responseCode.ResponseCodeDescriptions.Any())
            {
                responseCodeInfo.ResponseCodeDescriptionInfos = new List<ResponseCodeDescriptionInfo>();
                foreach (var responseCodeDescription in responseCode.ResponseCodeDescriptions)
                {
                    responseCodeInfo.ResponseCodeDescriptionInfos.Add(new ResponseCodeDescriptionInfo()
                    {
                        Description = responseCodeDescription.Description,
                        Message = responseCodeDescription.Message,
                        Language = responseCodeDescription.Language.Code,
                    });
                }
            }

            return responseCodeInfo;
        }

        public SearchResponseCodeInfoResponse ToSearchResponseCodeInfoResponse(IEnumerable<ResponseCode> responseCodes)
        {
            var searchResponseCodeInfoResponse = new SearchResponseCodeInfoResponse();

            IList<ResponseCodeInfo> responseCodeInfos = new List<ResponseCodeInfo>();

            foreach (var responseCode in responseCodes)
            {
                var responseCodeInfo = new ResponseCodeInfo
                {
                    Code = responseCode.Code
                };

                if (responseCode.ResponseCodeDescriptions.Any())
                {
                    responseCodeInfo.ResponseCodeDescriptionInfos = new List<ResponseCodeDescriptionInfo>();
                    foreach (var responseCodeDescription in responseCode.ResponseCodeDescriptions)
                    {
                        responseCodeInfo.ResponseCodeDescriptionInfos.Add(new ResponseCodeDescriptionInfo()
                        {
                            Description = responseCodeDescription.Description,
                            Message = responseCodeDescription.Message,
                            Language = responseCodeDescription.Language.Code,
                        });
                    }
                }

                responseCodeInfos.Add(responseCodeInfo);
            }

            searchResponseCodeInfoResponse.ResponseCodeInformations = responseCodeInfos;

            return searchResponseCodeInfoResponse;
        }

        public SearchResponseCodeInfoResponse ToSearchResponseCodeInfoResponse(ResponseCode responseCode)
        {
            var searchResponseCodeInfoResponse = new SearchResponseCodeInfoResponse();

            var responseCodeInfo = new ResponseCodeInfo
              {
                  Code = responseCode.Code
              };

            if (responseCode.ResponseCodeDescriptions.Any())
            {
                responseCodeInfo.ResponseCodeDescriptionInfos = new List<ResponseCodeDescriptionInfo>();
                foreach (var responseCodeDescription in responseCode.ResponseCodeDescriptions)
                {
                    responseCodeInfo.ResponseCodeDescriptionInfos.Add(new ResponseCodeDescriptionInfo()
                    {
                        Description = responseCodeDescription.Description,
                        Message = responseCodeDescription.Message,
                        Language = responseCodeDescription.Language.Code,
                    });
                }
            }

            searchResponseCodeInfoResponse.ResponseCodeInformations = new List<ResponseCodeInfo> { responseCodeInfo };

            return searchResponseCodeInfoResponse;
        }

        public SearchResponseCodeInfoResponse ToSearchResponseCodeInfoResponse(ResponseCodeInfo responseCodeInfo)
        {
            var searchResponseCodeInfoResponse = new SearchResponseCodeInfoResponse();

            searchResponseCodeInfoResponse.ResponseCodeInformations = new List<ResponseCodeInfo>();

            searchResponseCodeInfoResponse.ResponseCodeInformations.Add(responseCodeInfo);

            return searchResponseCodeInfoResponse;
        }

        public ResponseCode ToResponseCode(CreateResponseCodeRequest createResponseCodeRequest)
        {
            if (createResponseCodeRequest == null)
                return null;

            var responseCode = new ResponseCode();



            return responseCode;
        }

        public SearchResponseCodeInfoResponse ToSearchResponseCodeInfoResponse(IEnumerable<ResponseCodeInfo> responseCodes)
        {
            var searchResponseCodeInfoResponse = new SearchResponseCodeInfoResponse();

            searchResponseCodeInfoResponse.ResponseCodeInformations = responseCodes.ToList();

            return searchResponseCodeInfoResponse;
        }

        public CreateResponseCodeResponse ToCreateResponseCodeResponse(ResponseCode responseCode)
        {
            var createResponseCodeResponse = new CreateResponseCodeResponse();
            createResponseCodeResponse.Message = responseCode.Code;
            createResponseCodeResponse.ResponseCodeInfo = ToResponseCodeInfo(responseCode);
            return createResponseCodeResponse;
        }
    }
}
