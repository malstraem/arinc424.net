namespace Arinc424;

public readonly struct Section(char section, char subsection)
{
    internal readonly char Char = section;

    internal readonly char Subchar = subsection;

    internal bool IsWhiteSpace() => char.IsWhiteSpace(Char) && char.IsWhiteSpace(Subchar);

    public override string ToString() => $"{Char}, {Subchar}";
}
