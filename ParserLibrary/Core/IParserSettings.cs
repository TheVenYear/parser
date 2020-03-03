namespace ParserLibrary.Core
{
    public interface IParserSettings
    {
        string Url { get; set; }

        string Prefix { get; set; }

        int FirstIndex { get; set; }

        int SecondIndex { get; set; }
    }
}
