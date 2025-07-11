namespace Arinc424.Navigation;

[Known(14, 17), Continuous]

[DebuggerDisplay($"{{{nameof(Identifier)},nq}}")]
public abstract class Navaid : Fix, INamed
{
    /// <include file='Comments.xml' path="doc/member[@name='Frequency']/*"/>
    [Field(23, 27), Float(10)]
    public float Frequency { get; set; }

    /// <include file='Comments.xml' path="doc/member[@name='Datum']/*"/>
    [Field(91, 93)]
    public string? Datum { get; set; }

    /// <include file='Comments.xml' path="doc/member[@name='Name']/*"/>
    [Field(94, 123)]
    [Field<Omnidirect>(94, 123)]
    [Field<Omnidirect>(94, 122, Start = Supplement.V19)]
    [Field<Omnidirect>(94, 118, Start = Supplement.V20)]
    public string? Name { get; set; }
}
