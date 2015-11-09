using System.Runtime.Serialization;

namespace NorthwindDataServer.Store.Modules.Contracts
{
    [DataContract]
    public class ResponseCodeDescriptionInfo
    {
        [DataMember]
        public string Message { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public string Language { get; set; }
    }
}
