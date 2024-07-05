namespace Arinc424.Procedures;

[Identifier(14, 19), Icao(11, 12), Port(7, 10)]
[DebuggerDisplay($"{{{nameof(Identifier)},nq}}")]
public abstract class Procedure<TSequence, TSub> : Record424<TSequence>, IIdentity, IIcao
    where TSequence : ProcedureSequence<TSub>
    where TSub : ProcedurePoint
{
    public string IcaoCode { get; set; }

    /// <summary>
    /// <para>
    ///   <c>SID/STAR Route Identifier (SID/STAR IDENT)</c> field
    ///   for <see cref="AirportDeparture"/>, <see cref="AirportArrival"/>, <see cref="HeliportDeparture"/> and <see cref="HeliportArrival"/>.
    /// </para>
    /// <para>
    ///   <c>Approach Route Identifier (APPROACH IDENT)</c> field for <see cref="AirportApproach"/> and <see cref="HeliportApproach"/>.
    /// </para>
    /// </summary>
    /// <remarks>See section 5.9 or 5.10.</remarks>
    public string Identifier { get; set; }
}
