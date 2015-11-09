using System.Runtime.Serialization;

namespace NorthwindDataServer.Store.Modules.Contracts
{
    [DataContract]
    public class CheckUserRequest
    {
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public string Password { get; set; }
    }
}
