using Arinc424.Diagnostics;

namespace Arinc424.Attributes;

/// <summary>
/// Specifies that property value is an array and will be found within an ARINC-424 string using <see cref="FieldAttribute"/> range.
/// </summary>
internal abstract class CountAttribute<TType>(uint count) : DecodeAttribute<TType> where TType : notnull
{
    protected readonly uint count = count;

    internal abstract TType[] GetArray(Range range, ReadOnlySpan<char> @string, Queue<Diagnostic> diagnostics);
}

/// <inheritdoc />
[AttributeUsage(AttributeTargets.Property)]
internal sealed class CountAttribute<TConverter, TType>(uint count) : CountAttribute<TType>(count)
    where TConverter : IStringConverter<TConverter, TType>
    where TType : notnull
{
    internal override Result<TType> Convert(ReadOnlySpan<char> @string) => TConverter.Convert(@string);

    [Obsolete("todo")]
    internal override TType[] GetArray(Range range, ReadOnlySpan<char> @string, Queue<Diagnostic> diagnostics)
    {
        List<TType> list = [];

        int length = range.End.Value - range.Start.Value;

        for (int i = 0; i < count; i++)
        {
            var @field = @string[range];

            if (@field.IsWhiteSpace())
                break;

            // todo: process error
            list.Add(Convert(@field).Value);

            range = new(range.Start.Value + length, range.End.Value + length);
        }
        return [.. list];
    }
}
