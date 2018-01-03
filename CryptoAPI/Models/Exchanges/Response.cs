using System.IO;
using System.Net;

namespace CryptoAPI.Models.Exchanges
{
    public class Response
    {
        public string Text { get; set; }

        public Response(string url)
        {
            WebRequest req = WebRequest.Create(url);
            WebResponse resp = req.GetResponse();
            Stream stream = resp.GetResponseStream();
            if (stream != null)
            {
                var sr = new StreamReader(stream);
                var result = sr.ReadToEnd();
                sr.Close();
                Text=result;
            }
            else
            {
                Text=string.Empty;
            }
        }
    }
}