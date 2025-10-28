using System.Diagnostics;

namespace Arinc424.Generators;

[DebuggerDisplay($"{{{nameof(name)},nq}}, {{{nameof(value)},nq}}")]
internal class Member(string name, string value)
{
    protected internal readonly string name = name, value = value;

    internal void Deconstruct(out string name, out string value)
    {
        name = this.name;
        value = this.value;
    }

    internal Operand[]? Operands { get; set; }

    internal bool IsBlank => string.IsNullOrEmpty(value);
}

internal class Operand(string name, string value)
{
    private readonly string name = name, value = value;

    internal void Deconstruct(out string name, out string value)
    {
        name = this.name;
        value = this.value;
    }
}
