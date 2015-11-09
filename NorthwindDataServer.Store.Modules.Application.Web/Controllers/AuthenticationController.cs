using NorthwindDataServer.Store.Modules.Application.Web.Models;
using System.IO;
using System.Net;
using System.Text;
using System.Web.Mvc;

namespace NorthwindDataServer.Store.Modules.Application.Web.Controllers
{
    public class AuthenticationController : BaseController
    {
        public WebApplicationConfiguration WebApplicationConfiguration { get; private set; }

        public AuthenticationController(WebApplicationConfiguration webApplicationConfiguration)
        {
            WebApplicationConfiguration = webApplicationConfiguration;
        }

        public ViewResult Index()
        {
            return View();
        }

        public ViewResult CreateToken()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateToken(CreateTokenModel model)
        {
            var parameters = new
            {
                userName = model.UserName,
                password = model.Password
            };

            var request = (HttpWebRequest)WebRequest.Create(string.Format("{0}/{1}", WebApplicationConfiguration.StoreServiceQualifiedUrl, "auth/"));
            request.Method = "POST";
            var postBytes = Encoding.UTF8.GetBytes(System.Web.Helpers.Json.Encode(parameters));
            request.ContentType = "application/json; charset=UTF-8";
            request.Accept = "application/json";
            request.ContentLength = postBytes.Length;
            request.UserAgent = WebApplicationConfiguration.UserAgent;
            var requestStream = request.GetRequestStream();
            requestStream.Write(postBytes, 0, postBytes.Length);
            requestStream.Close();
            var response = (HttpWebResponse)request.GetResponse();
            string result;

            using (var rdr = new StreamReader(response.GetResponseStream()))
                result = rdr.ReadToEnd();

            model.Result = result;

            return View(model);
        }

    }
}