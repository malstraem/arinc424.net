using System.Diagnostics;

namespace Arinc424.Generators;

[DebuggerDisplay($"{{{nameof(fullName)},nq}}, {{{nameof(argument)},nq}}")]
internal class Member(string fullName, string argument)
{
    private readonly string fullName = fullName;

    private readonly string argument = argument;

    internal void Deconstruct(out string member, out string value)
    {
        member = fullName;
        value = argument;
    }

    internal readonly bool IsBlank = string.IsNullOrEmpty(argument);
}
