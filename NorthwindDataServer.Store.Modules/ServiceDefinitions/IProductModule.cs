
namespace NorthwindDataServer.Store.Modules.ServiceDefinitions
{
    public interface IProductModule
    {
        dynamic GetAllProducts(dynamic parameters);
        
        dynamic SearchProducts(dynamic parameters);
    }
}
