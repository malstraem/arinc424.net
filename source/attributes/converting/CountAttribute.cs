namespace Arinc424.Attributes;

/// <summary>
/// Specifies that property value is an array and will be found within an ARINC-424 string using <see cref="FieldAttribute"/> range.
/// </summary>
[AttributeUsage(AttributeTargets.Property)]
internal class CountAttribute(uint count) : Attribute
{
    internal uint Count { get; } = count;
}
