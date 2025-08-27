namespace Arinc424;

/**<summary>
Two letter ICAO code.
</summary>
<remarks>See section 5.14.</remarks>*/
[Decode<IcaoConverter, Icao>]
public readonly struct Icao(char first, char second)
{
    public readonly char First = first, Second = second;

    public override string ToString() => new([First, Second]);

    public void Deconstruct(out char first, out char second)
    {
        first = First;
        second = Second;
    }
}
