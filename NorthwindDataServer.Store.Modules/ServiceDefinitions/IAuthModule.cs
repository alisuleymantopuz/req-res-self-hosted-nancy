
namespace NorthwindDataServer.Store.Modules.ServiceDefinitions
{
    public interface IAuthModule
    {
        dynamic Authenticate(dynamic parameters);

        dynamic Administration(dynamic parameters);
    }
}
