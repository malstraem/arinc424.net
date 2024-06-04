using System.Reflection;
using System.Text.RegularExpressions;

namespace Arinc424.Building;

[DebuggerDisplay($"{{{nameof(Property)}}} - {{{nameof(index)}}}")]
internal abstract class IndexAssignmentInfo<TRecord>(PropertyInfo property, Regex? regex, int index, TransformAttribute? transform)
    : AssignmentInfo(property, regex) where TRecord : Record424
{
    protected readonly int index = index;

    protected readonly TransformAttribute? transform = transform;

    internal abstract void Process(TRecord record, ReadOnlySpan<char> @string);
}

internal class IndexAssignmentInfo<TRecord, TValue>(PropertyInfo property, Regex? regex, int index, TransformAttribute? transform)
    : IndexAssignmentInfo<TRecord>(property, regex, index, transform) where TRecord : Record424
{
    private readonly Action<TRecord, TValue> set = property.GetSetMethod()!.CreateDelegate<Action<TRecord, TValue>>();

    internal override void Process(TRecord record, ReadOnlySpan<char> @string)
    {
        char @char = @string[index];

        object value = transform is not null ? transform.Convert(@char) : @char;

        set(record, (TValue)value);
    }
}
