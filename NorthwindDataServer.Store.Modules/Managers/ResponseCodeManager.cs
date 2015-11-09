using NorthwindDataServer.Domain.Common;
using NorthwindDataServer.Orm.Common;
using NorthwindDataServer.Store.Modules.Assemblers;
using NorthwindDataServer.Store.Modules.Contracts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace NorthwindDataServer.Store.Modules.Managers
{
    public class ResponseCodeManager : IResponseCodeManager
    {
        public IResponseCodeRepository ResponseCodeRepository { get; private set; }

        public IResponseValueModuleAssembler ResponeValueRouteAssembler { get; private set; }

        public ResponseCodeManager(IResponseCodeRepository responseCodeRepository, IResponseValueModuleAssembler responeValueRouteAssembler)
        {
            ResponseCodeRepository = responseCodeRepository;

            ResponeValueRouteAssembler = responeValueRouteAssembler;
        }

        public SearchResponseCodeInfoResponse SearchResponseCodeInfo(SearchProductsRequest searchProductsRequest)
        {
            return ResponeValueRouteAssembler.ToSearchResponseCodeInfoResponse(ResponseCodeRepository.All());
        }

        public IEnumerable<ResponseCodeInfo> AllResponseCodes()
        {
            return ResponeValueRouteAssembler.ToResponseCodeInfoCollection(ResponseCodeRepository.All());
        }

        public ResponseCodeInfo FindResponseCodeById(Guid id)
        {
            return ResponeValueRouteAssembler.ToResponseCodeInfo(ResponseCodeRepository.FirstOrDefault(x => x.Id == id));
        }

        public ResponseCodeInfo FindResponseCodeByCode(string code)
        {
            return ResponeValueRouteAssembler.ToResponseCodeInfo(ResponseCodeRepository.FirstOrDefault(x => x.Code == code));
        }

        public ResponseCode Create(CreateResponseCodeRequest createResponseCode)
        {
            if (createResponseCode == null) return null;

            Language language = ResponseCodeRepository.LanguageGetByCode(createResponseCode.LanguageCode);

            if (language == null)
                return null;

            ResponseCode responseCode = this.ResponseCodeRepository.FirstOrDefault(x => x.Code == createResponseCode.Code.Trim()) ??
                                        new ResponseCode() { Code = createResponseCode.Code, Id = Guid.NewGuid() };


            if (responseCode.ResponseCodeDescriptions == null)
                responseCode.ResponseCodeDescriptions = new Collection<ResponseCodeDescription>();

            responseCode.ResponseCodeDescriptions.Add(new ResponseCodeDescription()
            {
                ResponseCode = responseCode,
                Language = language,
                Description = createResponseCode.Description,
                Message = createResponseCode.ShortMessage,
                Id = Guid.NewGuid()
            });

            this.ResponseCodeRepository.Update(responseCode);

            return responseCode;

        }
    }
}
