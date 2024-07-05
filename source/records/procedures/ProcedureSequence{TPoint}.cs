namespace Arinc424.Procedures;

[Sequenced(27, 29), Continuous(39)]
public abstract class ProcedureSequence<TPoint> : Record424<TPoint>, IIdentity, IIcao where TPoint : ProcedurePoint
{
    [Field(11, 12)]
    public string IcaoCode { get; set; }

    /// <summary>
    /// <para>
    ///   <c>SID/STAR Route Identifier (SID/STAR IDENT)</c> field for <see cref="DepartureSequence"/> and <see cref="ArrivalSequence"/>.
    /// </para>
    /// <para>
    ///   <c>Approach Route Identifier (APPROACH IDENT)</c> field for <see cref="ApproachSequence"/>.
    /// </para>
    /// </summary>
    /// <remarks>See section 5.9 and 5.10.</remarks>
    [Field(14, 19)]
    public string Identifier { get; set; }

    /// <summary>
    /// <c>Transition Identifier (TRANS IDENT)</c> field.
    /// </summary>
    /// <remarks>See section 5.11.</remarks>
    [Field(21, 25)]
    public string? Transition { get; set; }

    /// <inheritdoc cref="Terms.AircraftTypes"/>
    [Character(26)]
    public Terms.AircraftTypes AircraftTypes { get; set; }
}
