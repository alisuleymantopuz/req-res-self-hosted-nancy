using Nancy;
using Nancy.ModelBinding;
using NorthwindDataServer.Store.Modules.Assemblers;
using NorthwindDataServer.Store.Modules.Contracts;
using NorthwindDataServer.Store.Modules.Managers;
using NorthwindDataServer.Store.Modules.ServiceDefinitions;
using System;

namespace NorthwindDataServer.Store.Modules
{
    public class ResponseValueModule : NancyModule, IResponseValueModule
    {
        public IResponseCodeManager ResponseCodeManager { get; private set; }

        public IResponseValueModuleAssembler ResponseValueRouteAssembler { get; private set; }

        public ResponseValueModule(IResponseCodeManager responseCodeManager, IResponseValueModuleAssembler responseValueRouteAssembler):
            base("/response")
        {
            ResponseValueRouteAssembler = responseValueRouteAssembler;

            ResponseCodeManager = responseCodeManager;

            Get["/"] = AllResponseCodes;

            Get["/codeById/{ID}"] = FindResponseCodeByID;

            Get["/codeByCode/{CODE}"] = FindResponseCodeByCode;

            Post["/createCode"] = AddResponseCode;
        }


        public dynamic AddResponseCode(dynamic parameters)
        {
            var createResponseCode = this.Bind<CreateResponseCodeRequest>();

            var createResponseCodeResponse = ResponseValueRouteAssembler.ToCreateResponseCodeResponse(ResponseCodeManager.Create(createResponseCode));

            return Response.AsJson(createResponseCodeResponse);
        }

        public dynamic AllResponseCodes(dynamic parameters)
        {
            var allResponseCodes = ResponseValueRouteAssembler.ToSearchResponseCodeInfoResponse(ResponseCodeManager.AllResponseCodes());

            return Response.AsJson(allResponseCodes);
        }

        public dynamic FindResponseCodeByID(dynamic parameters)
        {
            Guid id = Guid.Parse(parameters.ID);

            var responseCode = ResponseValueRouteAssembler.ToSearchResponseCodeInfoResponse(ResponseCodeManager.FindResponseCodeById(id));

            return Response.AsJson(responseCode);
        }

        public dynamic FindResponseCodeByCode(dynamic parameters)
        {
            string code = parameters.CODE;

            var responseCode = ResponseValueRouteAssembler.ToSearchResponseCodeInfoResponse(ResponseCodeManager.FindResponseCodeByCode(code));

            return Response.AsJson(responseCode);
        }
    }
}
