using NorthwindDataServer.Store.Modules.Contracts;
using NorthwindDataServer.Store.Modules.Criterias;

namespace NorthwindDataServer.Store.Modules.Managers
{
    public interface IProductManager
    {
        SearchProductResponse ListProducts(SearchProductsRequest request);

        SearchProductResponse SearchProducts(SearchProductsRequest request,ProductCriterias productCriterias);
    }
}
