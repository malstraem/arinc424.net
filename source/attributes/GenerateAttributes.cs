namespace Arinc424.Attributes;

/// <summary>
/// Specifies that enum values are mapped to characters and <see cref="ICharConverter{TSelf, TType}"/> implementation must be generated.
/// </summary>
[AttributeUsage(AttributeTargets.Enum)]
internal class CharAttribute : Attribute;

/// <summary>
/// Specifies that enum values are mapped to strings or characters (in case of flags) and <see cref="IStringConverter{TSelf, TType}"/> implementation must be generated.
/// </summary>
[AttributeUsage(AttributeTargets.Enum)]
internal class StringAttribute : Attribute;

/// <summary>
/// Specifies the mapping value of an enum member. Default is blank.
/// </summary>
[AttributeUsage(AttributeTargets.Field)]
public class MapAttribute(string @string = " ") : Attribute
{
    internal MapAttribute(char @char) : this(@char.ToString()) { }

    public string Value { get; } = @string;
}

[AttributeUsage(AttributeTargets.Field)]
internal class Offset : Attribute;
