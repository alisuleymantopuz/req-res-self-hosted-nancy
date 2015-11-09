using NorthwindDataServer.Domain.Authentication;
using NorthwindDataServer.Domain.Common;
using NorthwindDataServer.Exceptions;
using NorthwindDataServer.Store.Modules.Assemblers;
using NorthwindDataServer.Store.Modules.Contracts;
using NorthwindDataServer.Store.Modules.QueryObject;
using System.Linq;

namespace NorthwindDataServer.Store.Modules.Managers
{
    public class ProductManager : IProductManager
    {
        public IUserRepository UserRepository { get; private set; }

        public IResponseCodeRepository ResponseCodeRepository { get; private set; }

        public IProductRepository ProductRepository { get; private set; }

        public IProductModuleAssembler ProductRoutesAssembler { get; private set; }

        public ProductManager(IUserRepository userRepository, IResponseCodeRepository responseCodeRepository, IProductRepository productRepository, IProductModuleAssembler productRoutesAssembler)
        {
            ProductRoutesAssembler = productRoutesAssembler;
            ProductRepository = productRepository;
            ResponseCodeRepository = responseCodeRepository;
            UserRepository = userRepository;
        }

        public SearchProductResponse ListProducts(SearchProductsRequest request)
        {

            //var isUserExist = this.UserRepository.CheckUser(request.UserName, request.Password);

            //if (isUserExist == null)
            //    return ProductRoutesAssembler.PopulateSearchResponseWithResponseCode(ExceptionCodes._1001);

            var searchProductsResponse = ProductRoutesAssembler.ToSearchProductResponse(this.ProductRepository.All());

            return searchProductsResponse;
        }


        public SearchProductResponse SearchProducts(SearchProductsRequest request, Criterias.ProductCriterias productCriterias)
        {
            //var isUserExist = this.UserRepository.CheckUser(request.UserName, request.Password);

            //if (isUserExist == null)
            //    return ProductRoutesAssembler.PopulateSearchResponseWithResponseCode(ExceptionCodes._1001);

            if (productCriterias == null)
                return ProductRoutesAssembler.PopulateSearchResponseWithResponseCode(ExceptionCodes._1002);

            var queryObject = new ProductQueryObject();

            if (productCriterias.Id.HasValue)
                queryObject.AddIdentityExpressionAND(productCriterias.Id.Value);

            if (!string.IsNullOrEmpty(productCriterias.Name))
                queryObject.AddNameExpressionAND(productCriterias.Name);

            var searchProductsResponse = ProductRoutesAssembler.ToSearchProductResponse(this.ProductRepository.Where(queryObject.Query()).ToList());

            return searchProductsResponse;
        }

    }
}
