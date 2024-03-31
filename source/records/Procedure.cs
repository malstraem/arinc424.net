using System.Diagnostics;

using Arinc.Spec424.Attributes;
using Arinc.Spec424.Converters;
using Arinc.Spec424.Terms;

namespace Arinc.Spec424.Records;

#pragma warning disable CS8618

/// <summary>
/// <c>Airport SID/STAR/Approach</c> primary record.
/// </summary>
/// <remarks>See section 4.1.9.1.</remarks>
[Continuous(39), Sequenced(27, 29)]
[DebuggerDisplay($"{{{nameof(Identifier)}}}")]
public abstract class Procedure : Record424<ProcedurePoint>, IIdentity
{
    [Foreign(7, 12)]
    public Airport Airport { get; init; }

    /// <summary>
    /// <para>
    ///   <c>SID/STAR Route Identifier (SID/STAR IDENT)</c> field.
    /// </para>
    /// <para>
    ///   <c>Approach Route Identifier (APPROACH IDENT)</c> field.
    /// </para>
    /// </summary>
    /// <remarks>See section 5.9, 5.10.</remarks>
    [Field(14, 19)]
    public string Identifier { get; init; }

    /// <summary>
    /// <c>Transition Identifier (TRANS IDENT)</c> field.
    /// </summary>
    /// <remarks>See section 5.11.</remarks>
    [Field(21, 25)]
    public string? TransitionIdentifier { get; init; }

    /// <inheritdoc cref="Terms.AircraftTypes"/>
    [Character(26), Transform<AircraftTypesConverter>]
    public AircraftTypes AircraftTypes { get; init; }
}
