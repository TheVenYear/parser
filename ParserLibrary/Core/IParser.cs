using HtmlAgilityPack;

namespace ParserLibrary.Core
{
    public interface IParser<T>
    {
        T Parse(HtmlDocument document);
    }
}
