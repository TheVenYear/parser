using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ParserLibrary.Core
{
    public class ParserWorker<T>
    {
        public event Action<object, T> OnNewData;
        HtmlLoader loader;
        IParserSettings settings;
        public IParserSettings Settings
        {
            get => settings;
            set
            {
                settings = value;
                loader = new HtmlLoader(value);
            }
        }
        public IParser<T> Parser { get; set; }
        public ParserWorker(IParser<T> parser)
        {
            Parser = parser;
        }

        public async void Work()
        {
            for (int i = settings.FirstIndex; i <= settings.SecondIndex; i++)
            {

                var document = await loader.LoadPageByIndex(i);
                OnNewData?.Invoke(this, Parser.Parse(document));
            }
        }
    }
}
