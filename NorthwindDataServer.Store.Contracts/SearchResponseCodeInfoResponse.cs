using System.Collections.Generic;
using System.Runtime.Serialization;

namespace NorthwindDataServer.Store.Modules.Contracts
{
    [DataContract]
    public class SearchResponseCodeInfoResponse
    {
        [DataMember]
        public IList<ResponseCodeInfo> ResponseCodeInformations { get; set; }
    }
}
