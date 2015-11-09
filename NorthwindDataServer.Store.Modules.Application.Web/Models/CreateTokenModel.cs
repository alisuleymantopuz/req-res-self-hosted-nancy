
using System.ComponentModel.DataAnnotations;
namespace NorthwindDataServer.Store.Modules.Application.Web.Models
{
    public class CreateTokenModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        public string Result { get; set; }
    }
}