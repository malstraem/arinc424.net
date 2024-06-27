namespace Arinc424.Attributes;

/// <summary>
/// Specifies that property value is an array and items will be found within an <c>ARINC-424</c> string using <see cref="FieldAttribute"/> range.
/// </summary>
[AttributeUsage(AttributeTargets.Property)]
internal class CountAttribute(uint count) : Attribute
{
    internal uint Count { get; } = count;
}
