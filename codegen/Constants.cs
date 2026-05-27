namespace Arinc424.Generators;

internal static class Constants
{
    internal const string
        CharAttributeQualifier = "Arinc424.Attributes.CharAttribute",
        StringAttributeQualifier = "Arinc424.Attributes.StringAttribute",

        MapAttribute = "Map",
        SumAttribute = "Sum<T>",
        CharAttribute = "Char",
        FlagsAttribute = "Flags",
        OffsetAttribute = "Offset",
        StringAttribute = "String",

        CharConverter = "ICharConverter",
        StringConverter = "IStringConverter",

        Char = "@char",
        String = "@string",

        CharArg = "char @char",
        StringArg = "ReadOnlySpan<char> @string",

        Unknown = "Unknown";
}
