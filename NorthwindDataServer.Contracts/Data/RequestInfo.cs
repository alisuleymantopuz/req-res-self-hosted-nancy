using System.Runtime.Serialization;

namespace NorthwindDataServer.Contracts.Data
{

    [DataContract]
    public class RequestInfo
    {
        [DataMember]
        public CredentialInfo CredentialInfo { get; set; }
    }
}
