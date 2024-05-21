namespace Arinc424.Attributes;

/// <summary>
/// Specifies that property value is an array and should be found within an ARINC-424 string using <see cref="FieldAttribute"/> range.
/// </summary>
[AttributeUsage(AttributeTargets.Property)]
internal abstract class CountAttributeAttribute(uint count) : Attribute
{
    protected uint count = count;

    internal abstract object GetArray(Range range, ReadOnlySpan<char> @string);
}

/// <inheritdoc />
internal sealed class CountAttribute<TType, TConverter>(uint count) : CountAttributeAttribute(count)
    where TType : notnull
    where TConverter : IStringConverter<TConverter, TType>
{
    internal override object GetArray(Range range, ReadOnlySpan<char> @string)
    {
        List<TType> list = [];

        int length = range.End.Value - range.Start.Value;

        for (int i = 0; i < count; i++)
        {
            var @field = @string[range];

            if (@field.IsWhiteSpace())
                break;

            list.Add(TConverter.Convert(@field));

            range = new(range.Start.Value + length, range.End.Value + length);
        }
        return list.ToArray();
    }
}
