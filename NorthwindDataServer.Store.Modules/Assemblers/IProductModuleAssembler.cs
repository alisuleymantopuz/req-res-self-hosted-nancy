using NorthwindDataServer.Orm.Common;
using NorthwindDataServer.Store.Modules.Contracts;
using System.Collections.Generic;

namespace NorthwindDataServer.Store.Modules.Assemblers
{
 public   interface IProductModuleAssembler
 {
     SearchProductResponse PopulateSearchResponseWithResponseCode(string responseCode);

     SearchProductResponse ToSearchProductResponse(IEnumerable<Product> products);
 }
}
