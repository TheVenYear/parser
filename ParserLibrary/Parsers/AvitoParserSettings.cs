using ParserLibrary.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserLibrary.Parsers
{
    public class AvitoParserSettings : IParserSettings
    {
        public string Url { get; set; } = "https://www.avito.ru/moskva/noutbuki/apple-ASgBAgICAUSEK_a2Ag";
        public string Prefix { get; set; } = "?p={value}";
        public int FirstIndex { get; set; }
        public int SecondIndex { get; set; }
    }
}
