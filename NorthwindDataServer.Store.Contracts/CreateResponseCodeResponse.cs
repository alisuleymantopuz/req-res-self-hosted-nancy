using System.Runtime.Serialization;

namespace NorthwindDataServer.Store.Modules.Contracts
{
    [DataContract]
    public class CreateResponseCodeResponse : ResponseBase
    {
        [DataMember]
        public ResponseCodeInfo ResponseCodeInfo { get; set; }
    }
}
