using RestSharp;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
namespace GoogleRequestWebAPI.Model
{
    public class Request
    {
        public string Query { get; private set; }

        public Request(string query)
        {
            this.Query = query;
        }

        public string GetData()
        {
            string searchQuery = this.Query.Replace(' ', '+');
            string sURL = "https://www.google.com/search?q=" + this.Query + "&oq=" + searchQuery + "&aqs=chrome..69i57j69i60l2j69i57j69i59j69i60.478j0j7&sourceid=chrome&ie=UTF-8";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(sURL);

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);



            string myResponse = HttpUtility.HtmlDecode(reader.ReadToEnd());

            return Encoding.UTF8.GetString(Encoding.Default.GetBytes(myResponse));
        }


        public Website GetWebsite(ref string html)
        {

            string findReference = "<div class=\"g\"><h3 class=\"r\"><a href=\"/url?q=";
            string findStart = "\">";
            string endUrl = "&sa=";
            string findEnd = "</a></h3>";


            int posReference = html.IndexOf(findReference) + findReference.Length;
            if (posReference >= findReference.Length)
            {
                int urlEndPos = html.IndexOf(endUrl, posReference);
                string url = html.Substring(posReference, urlEndPos - posReference );

                html = html.Substring(html.IndexOf(findStart, posReference) + findStart.Length);
                int posEnd = html.IndexOf(findEnd);

                string title = html.Substring(0, posEnd);

                return new Website(Regex.Replace(title, "<.*?>", string.Empty), url);
            }
            else
            {
                return null;
            }


        }



    }
}
