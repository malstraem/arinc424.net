namespace Arinc424.Attributes;

[AttributeUsage(AttributeTargets.Property)]
internal sealed class IntegerAttribute : DecodeAttribute<int>
{
    internal override Result<int> Convert(ReadOnlySpan<char> @string) => IntConverter.Convert(@string);
}
