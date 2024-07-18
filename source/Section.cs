namespace Arinc424;

public readonly struct Section(char section, char subsection)
{
    internal readonly char Char = section;

    internal readonly char Subchar = subsection;

    public override string ToString() => $"{Char}, {Subchar}";
}
