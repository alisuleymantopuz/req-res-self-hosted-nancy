using NorthwindDataServer.Infastructure.Configuration;

namespace NorthwindDataServer.Store.Modules.Application.Web
{
    public class WebApplicationConfiguration : ConfigurationStore
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

        public string UserAgent
        {
            get
            {
                return this.GetStringValue("UserAgent");
            }
        }
    }
}
