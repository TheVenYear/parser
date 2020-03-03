using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ParserLibrary.Core
{
    public class HtmlLoader
    {
        string url, prefix;
        public HtmlLoader(IParserSettings settings)
        {
            url = $"{settings.Url}{settings.Prefix}";
            prefix = settings.Prefix;
        }

        public async Task<HtmlDocument> LoadPageByIndex(int index)
        {
            using (WebClient client = new WebClient())
            {
                client.Encoding = Encoding.UTF8;
                var html = await client.DownloadStringTaskAsync(url.Replace("{value}", index.ToString()));
                var document = new HtmlDocument();
                document.LoadHtml(html);
                return document;
            }
        }
    }
}
