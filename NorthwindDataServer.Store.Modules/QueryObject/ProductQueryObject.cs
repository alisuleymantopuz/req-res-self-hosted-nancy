using NorthwindDataServer.Infastructure.Querying;
using NorthwindDataServer.Orm.Common;

namespace NorthwindDataServer.Store.Modules.QueryObject
{
    public class ProductQueryObject : QueryObject<Product>
    {
        public void AddIdentityExpressionAND(int Id)
        {
            And(x => x.ProductId == Id);
        }


        public void AddNameExpressionAND(string name)
        {
            And(x => x.ProductName.Contains(name));
        }
    }
}
