using System.Runtime.Serialization;

namespace NorthwindDataServer.Store.Modules.Contracts
{
    [DataContract]
    public class SearchResponseCodeInfoRequest 
    {
        [DataMember]
        public string Code { get; set; }

    }
}
