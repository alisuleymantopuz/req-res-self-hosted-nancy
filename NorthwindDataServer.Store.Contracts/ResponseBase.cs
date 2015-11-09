using System.Runtime.Serialization;

namespace NorthwindDataServer.Store.Modules.Contracts
{
    [DataContract]
    public class ResponseBase
    {
        [DataMember]
        public string ResponseCode { get; set; }

        [DataMember]
        public string Message { get; set; }
    }
}
