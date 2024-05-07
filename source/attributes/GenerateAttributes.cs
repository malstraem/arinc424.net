namespace Arinc424.Attributes;

[AttributeUsage(AttributeTargets.Enum)]
internal class CharAttribute : Attribute;

[AttributeUsage(AttributeTargets.Enum)]
internal class StringAttribute : Attribute;

[AttributeUsage(AttributeTargets.Field)]
public class MapAttribute : Attribute
{
    internal MapAttribute(char @char) => Value = @char.ToString();

    internal MapAttribute(string @string) => Value = @string;

    public string Value { get; }
}
