using System.Collections.Generic;

namespace NorthwindDataServer.Store.Modules.Contracts
{
    public class SearchProductResponse :ResponseBase
    {
        public List<ProductInfo> ProductInfos { get; set; }
    }
}
