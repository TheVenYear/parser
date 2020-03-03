using HtmlAgilityPack;
using ParserLibrary.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserLibrary.Parsers
{
    public class AvitoParser : IParser<IEnumerable<string>>
    {
        public IEnumerable<string> Parse(HtmlDocument document)
        {
            var links = document.DocumentNode.SelectNodes(".//h3");
            foreach (var link in links)
            {
                yield return link.InnerText;
            }
        }
    }
}
