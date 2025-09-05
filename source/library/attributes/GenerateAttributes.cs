namespace Arinc424.Attributes;

/**<summary>
Specifies that enum values are mapped to characters
and <see cref="ICharConverter{TType}"/> implementation will be generated.
</summary>*/
[AttributeUsage(AttributeTargets.Enum)]
internal sealed class CharAttribute : Attribute;

/**<summary>
Specifies that enum values are mapped to strings or characters (in case of flags)
and <see cref="IStringConverter{TType}"/> implementation will be generated.
</summary>*/
[AttributeUsage(AttributeTargets.Enum)]
internal sealed class StringAttribute : Attribute;

/**<summary>
Specifies that the member starts new array of mapping values
within an <c>ARINC-424</c> string.
</summary>*/
[AttributeUsage(AttributeTargets.Field)]
internal sealed class Offset : Attribute;

/**<summary>
Specifies the mapping value of an enum member. Default is blank.
</summary>*/
[AttributeUsage(AttributeTargets.Field)]
internal sealed class MapAttribute(string @string = "") : Attribute
{
    internal MapAttribute(char @char) : this(@char.ToString()) { }

    internal string Value { get; } = @string;
}
