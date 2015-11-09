
namespace NorthwindDataServer.Store.Modules.ServiceDefinitions
{
    public interface IResponseValueModule
    {
        dynamic AddResponseCode(dynamic parameters);

        dynamic AllResponseCodes(dynamic parameters);

        dynamic FindResponseCodeByID(dynamic parameters);

        dynamic FindResponseCodeByCode(dynamic parameters);
    }
}
