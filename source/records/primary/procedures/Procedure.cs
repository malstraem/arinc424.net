using System.Diagnostics;

using Arinc424.Attributes;
using Arinc424.Converters;
using Arinc424.Ports;

namespace Arinc424.Procedures;

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
    public Airport Airport { get; set; }

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
    [Character(26), Transform<AircraftTypesConverter>]
    public Terms.AircraftTypes AircraftTypes { get; set; }
}
