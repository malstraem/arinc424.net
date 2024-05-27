using Arinc424.Diagnostics;

namespace Arinc424.Attributes;

/// <summary>
/// Specifies that property value is an array and will be found within an ARINC-424 string using <see cref="FieldAttribute"/> range.
/// </summary>
[AttributeUsage(AttributeTargets.Property)]
internal abstract class CountAttribute(uint count) : Attribute
{
    protected uint count = count;

    internal abstract object GetArray(Range range, ReadOnlySpan<char> @string, Queue<Diagnostic> diagnostics);
}

/// <inheritdoc />
internal sealed class CountAttribute<TType, TConverter>(uint count) : CountAttribute(count)
    where TType : notnull
    where TConverter : IStringConverter<TConverter, TType>
{
    [Obsolete("todo")]
    internal override object GetArray(Range range, ReadOnlySpan<char> @string, Queue<Diagnostic> diagnostics)
    {
        List<TType> list = [];

        int length = range.End.Value - range.Start.Value;

        for (int i = 0; i < count; i++)
        {
            var @field = @string[range];

            if (@field.IsWhiteSpace())
                break;

            // todo: process error
            list.Add(TConverter.Convert(@field).Value);

            range = new(range.Start.Value + length, range.End.Value + length);
        }
        return list.ToArray();
    }
}
