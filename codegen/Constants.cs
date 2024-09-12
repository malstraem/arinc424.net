namespace Arinc424.Generators;

internal static class Constants
{
    internal const string CharAttributeQualifier = "Arinc424.Attributes.CharAttribute";
    internal const string StringAttributeQualifier = "Arinc424.Attributes.StringAttribute";

    internal const string MapAttribute = "Map";
    internal const string CharAttribute = "Char";
    internal const string FlagsAttribute = "Flags";
    internal const string OffsetAttribute = "Offset";
    internal const string StringAttribute = "String";

    internal const string StringConverter = "IStringConverter";
    internal const string CharConverter = "ICharConverter";

    internal const string String = "@string";
    internal const string Char = "@char";

    internal const string StringArgs = "ReadOnlySpan<char> @string";
    internal const string CharArgs = "char @char";
}
