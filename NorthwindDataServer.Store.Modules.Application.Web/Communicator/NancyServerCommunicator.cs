
namespace NorthwindDataServer.Store.Modules.Application.Web.Communicator
{
    public class NancyServerCommunicator
    {
        public WebApplicationConfiguration WebApplicationConfiguration { get; private set; }

        public NancyServerCommunicator(WebApplicationConfiguration webApplicationConfiguration)
        {
            WebApplicationConfiguration = webApplicationConfiguration;
        }

        //public string HttpGet(RequestBase requestBase)
        //{
        //    var req = WebRequest.Create(WebApplicationConfiguration.StoreServiceQualifiedUrl);
        //    byte[] bytes = System.Text.Encoding.ASCII.GetBytes(Parameters);
        //    req.ContentLength = bytes.Length;
        //    Stream os = req.GetRequestStream();
        //    os.Write(bytes, 0, bytes.Length); 
        //    os.Close();
        //    var resp = req.GetResponse();
        //    var sr = new StreamReader(resp.GetResponseStream());
        //    return sr.ReadToEnd().Trim();
        //}

        //public string HttpPost(RequestBase requestBase)
        //{
        //    WebRequest req = WebRequest.Create(WebApplicationConfiguration.StoreServiceQualifiedUrl);  
        //    req.ContentType = "application/x-www-form-urlencoded";
        //    req.Method = "POST"; 
        //    byte[] bytes = System.Text.Encoding.ASCII.GetBytes(requestBase);
        //    req.ContentLength = bytes.Length;
        //    System.IO.Stream os = req.GetRequestStream();
        //    os.Write(bytes, 0, bytes.Length);
        //    os.Close();
        //    System.Net.WebResponse resp = req.GetResponse();
        //    if (resp == null) return null;
        //    System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream());
        //    return sr.ReadToEnd().Trim();
        //}
    }

    //public static class RequestBaseExtensions
    //{

    //}

}