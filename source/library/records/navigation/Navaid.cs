namespace Arinc424.Navigation;

[Continuous, Identifier(14, 17), Icao(20, 21)]

[DebuggerDisplay($"{{{nameof(Identifier)},nq}}")]
public abstract class Navaid : Fix, IIcao, INamed
{
    [Field(20, 21)]
    public string Icao { get; set; }

    /// <include file='Comments.xml' path="doc/member[@name='Frequency']/*"/>
    [Field(23, 27), Float(10)]
    public float Frequency { get; set; }

    /// <include file='Comments.xml' path="doc/member[@name='Datum']/*"/>
    [Field(91, 93)]
    public string? Datum { get; set; }

    /// <include file='Comments.xml' path="doc/member[@name='Name']/*"/>
    [Field(94, 123)]
    [Field<Omnidirectional>(94, 123)]
    [Field<Omnidirectional>(94, 122, Supplement.V19)]
    [Field<Omnidirectional>(94, 118, Supplement.V20)]
    public string? Name { get; set; }
}
