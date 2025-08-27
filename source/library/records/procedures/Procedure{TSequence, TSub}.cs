namespace Arinc424.Procedures;

/**<summary>
Fields of <c>Airport</c> and <c>Heliport SID/STAR/Approach</c>.
</summary>*/
[Port(7, 10), Icao(11, 12), Id(14, 19), Continuous(39)]

[DebuggerDisplay($"{{{nameof(Identifier)},nq}}, {{{nameof(Port)}}}")]
public abstract class Procedure<TSequence, TSub> : Record424<TSequence>, IIdentity, IIcao
    where TSequence : ProcedureSequence<TSub>
    where TSub : ProcedurePoint
{
    public Ground.Port Port { get; set; }

    [Field(11, 12)]
    public Icao Icao { get; set; }

    /**<summary>
    <para>
      <c>SID/STAR Route Identifier (SID/STAR IDENT)</c> field for <see cref="Departure"/> and <see cref="Arrival"/>.
    </para>
    <para>
      <c>Approach Route Identifier (APPROACH IDENT)</c> field for <see cref="Approach"/>.
    </para>
    </summary>
    <remarks>See section 5.9 or 5.10.</remarks>*/
    [Field(14, 19)]
    public string Identifier { get; set; }
}
