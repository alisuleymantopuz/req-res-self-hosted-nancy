using System.Runtime.Serialization;

namespace NorthwindDataServer.Store.Modules.Contracts
{
    [DataContract]
    public class CheckUserResponse
    {
        [DataMember]
        public bool IsUserExist { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Surname { get; set; }

        [DataMember]
        public string Username { get; set; }
    }
}
