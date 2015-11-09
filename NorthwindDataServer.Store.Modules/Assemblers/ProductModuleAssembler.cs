using NorthwindDataServer.Domain.Common;
using NorthwindDataServer.Exceptions;
using NorthwindDataServer.Orm.Common;
using NorthwindDataServer.Store.Modules.Contracts;
using System.Collections.Generic;
using System.Linq;
namespace NorthwindDataServer.Store.Modules.Assemblers
{
    public class ProductModuleAssembler : IProductModuleAssembler
    {

        public IResponseCodeRepository ResponseCodeRepository { get; private set; }

        public ProductModuleAssembler(IResponseCodeRepository responseCodeRepository)
        {
            ResponseCodeRepository = responseCodeRepository;
        }

        public SearchProductResponse PopulateSearchResponseWithResponseCode(string responseCode)
        {
            var searchProductResponse = new SearchProductResponse { ResponseCode = responseCode };

            var codeDetail = ResponseCodeRepository.FirstOrDefault(x => x.Code == responseCode);

            if (codeDetail == null || codeDetail.ResponseCodeDescriptions == null ||
                !codeDetail.ResponseCodeDescriptions.Any()) return searchProductResponse;

            var descriptionModel = codeDetail.ResponseCodeDescriptions.FirstOrDefault(x => x.Language.Code == "en-EN");

            if (descriptionModel != null)
                searchProductResponse.Message = descriptionModel.Message;

            return searchProductResponse;
        }


        public SearchProductResponse ToSearchProductResponse(IEnumerable<Product> products)
        {
            var searchProductResponse = PopulateSearchResponseWithResponseCode(ExceptionCodes._0000);
            searchProductResponse.ProductInfos = new List<ProductInfo>();

            if (products == null || !products.Any()) return searchProductResponse;

            foreach (var product in products)
            {
                searchProductResponse.ProductInfos.Add(new ProductInfo()
                {
                    Id = product.ProductId,
                    Name = product.ProductName,
                    ReorderLevel = product.ReorderLevel,
                    UnitPrice = product.UnitPrice,
                    UnitsInStock = product.UnitsInStock
                });
            }

            return searchProductResponse;
        }
    }
}
