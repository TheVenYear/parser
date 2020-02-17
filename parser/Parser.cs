using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace parser
{
    public class Parser
    {
        private string a(string url)
        {
            var request = WebRequest.CreateHttp(url);
            HttpWebResponse response;
            try
            {
                response = (HttpWebResponse)request.GetResponse();
            }
            catch
            {
                throw null;
            }

            if (response.StatusCode != HttpStatusCode.OK)
            {
                return "Зайти на сайт не получилось";
            }

            var reader = new StreamReader(response.GetResponseStream());
            var result = reader.ReadToEnd();
            response.Close();
            reader.Close();
            return result;

        }

        public IEnumerable<string> d(string url)
        {
            var html = a(url);
            var document = new HtmlDocument();
            document.LoadHtml(html);
            var links = document.DocumentNode.SelectNodes(".//div[@class='shedule-container']/div[@class='row']//h4");
            if (links != null)
            {
                foreach (var link in links)
                {
                    yield return link.InnerText.Replace("\n", "");
                }
            }
            else
            {
                yield return "Не найдено";
            }
        }
    }
}
