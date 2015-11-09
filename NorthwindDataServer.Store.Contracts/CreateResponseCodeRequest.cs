using System.Runtime.Serialization;

namespace NorthwindDataServer.Store.Modules.Contracts
{
    [DataContract]
    public class CreateResponseCodeRequest
    {
        [DataMember]
        public string Code { get; set; }

        [DataMember]
        public string LanguageCode { get; set; }

        [DataMember]
        public string ShortMessage { get; set; }

        [DataMember]
        public string Description { get; set; }
    }
}
