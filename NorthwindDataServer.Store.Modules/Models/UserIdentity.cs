using Nancy.Security;
using System.Collections.Generic;

namespace NorthwindDataServer.Store.Modules.Models
{
    public class UserIdentity : IUserIdentity
    {
        public string UserName { get; set; }
        public IEnumerable<string> Claims { get; set; }
    }
}
