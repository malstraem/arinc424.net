namespace Arinc424;

/**<summary>
Character pair that defines entity type of an <c>ARINC424</c> string.
</summary>*/
public readonly struct Section(char @char, char sub)
{
    internal readonly char Char = @char, Sub = sub;

    internal bool IsWhiteSpace() => char.IsWhiteSpace(Char) && char.IsWhiteSpace(Sub);

    public override string ToString() => $"{Char}, {Sub}";
}
