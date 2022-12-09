using Test_API_Search.Models;
using System.Net;
using System.IO;
using static Test_API_Search.Business.SearchBusiness;

namespace Test_API_Search.Business
{
    public class SearchBusiness
    {
        public void SearchRequest(string Search)
        {
            var searchRequest = WebRequest.CreateHttp("https://www.google.com.br/search?q=atak+sistemas");
            searchRequest.Method = "GET";
            searchRequest.UserAgent = "Mozilla / 5.0(Windows; U; Windows NT 6.1; rv: 2.2) Gecko / 20110201";

            using (var response = searchRequest.GetResponse())
            {
                var streamDados = response.GetResponseStream();
                StreamReader reader = new StreamReader(streamDados);
                string objResponse = reader.ReadToEnd();

                var parametro = objResponse.Split(new string[] { @"url?q\x3d" }, StringSplitOptions.None)[1].Split(@"\x26amp");

                //var post = JsonConvert.DeserializeObject<Post>(objResponse.ToString());

                //Console.WriteLine(post.Id + " " + post.title + " " + post.body);
                //Console.ReadLine();
                //streamDados.Close();
                //response.Close();

                List<Search> lista = new List<Search>();
                foreach (Search search in lista)
                {
                    if (search.Titulo != )
                    {
                        return;
                    }
                }
            }

            //Console.ReadLine();

        }
      
    }
}
