namespace Arinc424;

internal readonly struct Section(char section, char subsection)
{
    internal readonly char Char = section;

    internal readonly char Subchar = subsection;
}
