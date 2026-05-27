using System.Reflection;

namespace Arinc424.Building;

[DebuggerDisplay($"{{{nameof(property)}}} - {{{nameof(index)}}}")]
internal abstract class IndexAssignment<R>(PropertyInfo property, int index)
    : Assignment<R>(property)
        where R : Record424
{
    protected readonly int index = index;
}

internal sealed class TransformAssignment<R, T>(PropertyInfo property, int index, TransformAttribute<T> transform)
    : IndexAssignment<R>(property, index)
        where R : Record424
        where T : Enum
{
    private readonly TransformAttribute<T> transform = transform;

    private readonly Action<R, T> set = property.GetSetMethod()!.CreateDelegate<Action<R, T>>();

    internal override void Assign(R record, ReadOnlySpan<char> @string, Queue<Diagnostic> diagnostics)
    {
        char @char = @string[index];

        if (transform.TryConvert(@char, out var value))
        {
            set(record, value);
            return;
        }
        diagnostics.Enqueue(new BadValue()
        {
            Range = index..index,
            Record = record,
            Property = property,
            Value = [@char]
        });
    }
}

internal sealed class CharAssignment<R>(PropertyInfo property, int index)
    : IndexAssignment<R>(property, index)
        where R : Record424
{
    private readonly Action<R, char> set = GetCompiledSetter<char>(property);

    internal override void Assign(R record, ReadOnlySpan<char> @string, Queue<Diagnostic> _) => set(record, @string[index]);
}
