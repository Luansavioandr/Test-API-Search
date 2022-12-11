using HtmlAgilityPack;
using System.Net;
using System.Text;
using System.Web;
using Test_API_Search.Models;

namespace Test_API_Search.Business
{
    public class SearchBusiness
    {
        public List<Search> SearchRequest(string Search)
        {
            StringBuilder sb = new StringBuilder();
            byte[] ResultsBuffer = new byte[8192];
            string SearchResults = "https://www.google.com.br/search?q=" + Search.Replace(" ","+");
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(SearchResults);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            Stream resStream = response.GetResponseStream();
            string tempString = null;
            int count = 0;
            do
            {
                count = resStream.Read(ResultsBuffer, 0, ResultsBuffer.Length);
                if (count != 0)
                {
                    tempString = Encoding.ASCII.GetString(ResultsBuffer, 0, count);
                    sb.Append(tempString);
                }
            }

            while (count > 0);
            string sbb = sb.ToString();

            HtmlAgilityPack.HtmlDocument html = new HtmlAgilityPack.HtmlDocument();
            html.OptionOutputAsXml = true;
            html.LoadHtml(sbb);
            HtmlNode doc = html.DocumentNode;
            List<Search> results = new List<Search>();  
            foreach (HtmlNode link in doc.SelectNodes("//a[@href]"))
            {
                string hrefValue = link.GetAttributeValue("href", string.Empty);
                if (!hrefValue.ToString().ToUpper().Contains("GOOGLE") && hrefValue.ToString().Contains("/url?q=") && ( hrefValue.ToString().ToUpper().Contains("HTTP://") || hrefValue.ToString().ToUpper().Contains("HTTPS://")))
                {
                    int index = hrefValue.IndexOf("&");
                    if (index > 0)
                    {
                        Search search = new Search();
                        hrefValue = hrefValue.Substring(0, index);
                        search.Link = hrefValue.Replace("/url?q=", "");
                        search.Titulo = link.InnerText;
                        results.Add(search);

                    }
                }
            }
           return results;
        }
      
    }
}
