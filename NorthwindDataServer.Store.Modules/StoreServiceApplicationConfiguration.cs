using NorthwindDataServer.Infastructure.Configuration;

namespace NorthwindDataServer.Store.Modules
{
    public class StoreServiceApplicationConfiguration : ConfigurationStore
    {
        public string StoreServiceHostUrl
        {
            get
            {
                return this.GetStringValue("StoreServiceHostUrl");
            }
        }

        public string StoreServiceHostPort
        {
            get
            {
                return this.GetStringValue("StoreServiceHostPort");
            }
        }

        public string StoreServiceQualifiedUrl
        {
            get
            {
                return string.Format("{0}:{1}", StoreServiceHostUrl, StoreServiceHostPort);
            }
        }
    }
}
