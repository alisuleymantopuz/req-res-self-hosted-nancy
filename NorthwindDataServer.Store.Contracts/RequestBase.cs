using System.Runtime.Serialization;

namespace NorthwindDataServer.Store.Modules.Contracts
{
    [DataContract]
    public class RequestBase
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public string Token { get; set; }
    }
}
