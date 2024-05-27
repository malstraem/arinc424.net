namespace Arinc424.Attributes;

[AttributeUsage(AttributeTargets.Property)]
internal class IntegerAttribute : DecodeAttribute
{
    internal override Result<object> Convert(ReadOnlySpan<char> @string) => IntConverter.Convert(@string).Box();
}
