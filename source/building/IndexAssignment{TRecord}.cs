using System.Reflection;
using System.Text.RegularExpressions;

using Arinc424.Diagnostics;

namespace Arinc424.Building;

[DebuggerDisplay($"{{{nameof(Property)}}} - {{{nameof(index)}}}")]
internal abstract class IndexAssignment<TRecord>(PropertyInfo property, Regex? regex, int index)
    : Assignment<TRecord>(property, regex) where TRecord : Record424
{
    protected readonly int index = index;
}

internal sealed class TransformAssignment<TRecord, TType>(PropertyInfo property, Regex? regex, int index, TransformAttribute<TType> transform)
    : IndexAssignment<TRecord>(property, regex, index) where TRecord : Record424 where TType : Enum
{
    private readonly TransformAttribute<TType> transform = transform;

    private readonly Action<TRecord, TType> set = property.GetSetMethod()!.CreateDelegate<Action<TRecord, TType>>();

    internal override void Assign(TRecord record, ReadOnlySpan<char> @string, Queue<Diagnostic> _) => set(record, transform.Convert(@string[index]));
}

internal sealed class CharAssignment<TRecord>(PropertyInfo property, Regex? regex, int index)
    : IndexAssignment<TRecord>(property, regex, index) where TRecord : Record424
{
    private readonly Action<TRecord, char> set = property.GetSetMethod()!.CreateDelegate<Action<TRecord, char>>();

    internal override void Assign(TRecord record, ReadOnlySpan<char> @string, Queue<Diagnostic> _) => set(record, @string[index]);
}
