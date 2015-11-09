using System.Runtime.Serialization;

namespace NorthwindDataServer.Contracts.Data
{
    [DataContract]
    public class CredentialInfo
    {
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public string Password { get; set; }
    }
}
