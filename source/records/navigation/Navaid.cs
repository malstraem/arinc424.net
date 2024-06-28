namespace Arinc424.Navigation;

[DebuggerDisplay($"{{{nameof(Identifier)},nq}}")]
public abstract class Navaid : Geo, IIdentity, IIcao, INamed
{
    /// <include file='Comments.xml' path="doc/member[@name='Navaid']/*"/>
    [Field(14, 17), Primary]
    public string Identifier { get; set; }

    [Field(20, 21), Primary]
    public string IcaoCode { get; set; }

    /// <include file='Comments.xml' path="doc/member[@name='Frequency']/*"/>
    [Field(23, 27), Float(10)]
    public float Frequency { get; set; }

    /// <include file='Comments.xml' path="doc/member[@name='Datum']/*"/>
    [Field(91, 93)]
    public string? Datum { get; set; }

    /// <include file='Comments.xml' path="doc/member[@name='Name']/*"/>
    [Field(94, 118), Field<Nondirectional>(94, 123)]
    public string? Name { get; set; }
}
