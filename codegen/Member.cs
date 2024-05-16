namespace Arinc424.Generators;

internal class Member(string fullName, string argument)
{
    internal void Deconstruct(out string member, out string value)
    {
        member = fullName;
        value = argument;
    }

    internal readonly bool IsBlank = string.IsNullOrEmpty(argument);
}
