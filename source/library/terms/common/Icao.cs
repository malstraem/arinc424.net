namespace Arinc424;

/**<summary>
Two letter ICAO code.
</summary>*/
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
