namespace Arinc424.Procedures;

#pragma warning disable CS8618

[Continuous(39), Sequenced(27, 29)]
[DebuggerDisplay($"{{{nameof(Identifier)}}}")]
public abstract class Procedure<TPoint> : Record424<TPoint>, IIdentity where TPoint : ProcedurePoint
{
    /// <summary>
    /// <para>
    ///   <c>SID/STAR Route Identifier (SID/STAR IDENT)</c> field. See section 5.9.
    /// </para>
    /// <para>
    ///   <c>Approach Route Identifier (APPROACH IDENT)</c> field. See section 5.10.
    /// </para>
    /// </summary>
    [Field(14, 19)]
    public string Identifier { get; set; }

    /// <summary>
    /// <c>Transition Identifier (TRANS IDENT)</c> field.
    /// </summary>
    /// <remarks>See section 5.11.</remarks>
    [Field(21, 25)]
    public string? TransitionIdentifier { get; set; }

    /// <inheritdoc cref="Terms.AircraftTypes"/>
    [Character(26)]
    public Terms.AircraftTypes AircraftTypes { get; set; }
}
