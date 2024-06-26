namespace Arinc424.Procedures;

[DebuggerDisplay($"{{{nameof(Identifier)},nq}}")]
public abstract class Procedure<TSequence, TSub> : Record424<TSequence>, IIdentity, IIcao where TSequence : ProcedureSequence<TSub> where TSub : ProcedurePoint
{
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
    [Field(14, 19), Primary, Obsolete("todo: so dirty, linking need to be reworked -_-")]
    public string Identifier { get; set; }

    [Field(11, 12), Primary, Obsolete("same")]
    public string IcaoCode { get; set; }
}
