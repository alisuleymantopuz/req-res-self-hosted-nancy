using NorthwindDataServer.Infastructure.Extensions; 

namespace NorthwindDataServer.Store.Modules.Models
{
    public class CredentialItem
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public CredentialItem(string encodedUserNameAndPassword)
        {
            try
            {
                var decodedUserNameAndPassword = encodedUserNameAndPassword.Base64Decode().Split(':');

                UserName = decodedUserNameAndPassword[0];

                Password = decodedUserNameAndPassword[1];
            }
            catch
            {
                //Logging
            }
        }
    }
}
