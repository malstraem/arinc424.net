namespace Arinc424.Attributes;

/// <summary>
/// Specifies that property value is a integer and will be parsed.
/// </summary>
[AttributeUsage(AttributeTargets.Property)]
internal sealed class IntegerAttribute : DecodeAttribute<int>
{
    internal override Result<int> Convert(ReadOnlySpan<char> @string) => IntConverter.Convert(@string);
}
