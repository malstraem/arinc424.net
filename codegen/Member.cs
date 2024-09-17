using System.Diagnostics;

namespace Arinc424.Generators;

[DebuggerDisplay($"{{{nameof(name)},nq}}, {{{nameof(argument)},nq}}")]
internal class Member(string name, string argument)
{
    private readonly string name = name;

    private readonly string argument = argument;

    internal void Deconstruct(out string member, out string value)
    {
        member = name;
        value = argument;
    }

    internal readonly bool IsBlank = string.IsNullOrEmpty(argument);
}
