using System.Collections.Generic;
using System.Runtime.Serialization;

namespace NorthwindDataServer.Store.Modules.Contracts
{
    [DataContract]
    public class ResponseCodeInfo
    {
        [DataMember]
        public string Code { get; set; }

        [DataMember]
        public List<ResponseCodeDescriptionInfo> ResponseCodeDescriptionInfos { get; set; }
    }
}
