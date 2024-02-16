using System.Diagnostics;

using Arinc.Spec424.Attributes;
using Arinc.Spec424.Records.Subsequences;

namespace Arinc.Spec424.Records;

#pragma warning disable CS8618

/// <summary>
/// <c>Airport SID/STAR/Approach</c> primary record.
/// </summary>
/// <remarks>See paragraph 4.1.9.1.</remarks>
[Continuation(39), Sequenced(27, 29)]
[DebuggerDisplay($"{{{nameof(Identifier)}}}")]
public abstract class Procedure : Record424<ProcedurePoint>, IIdentity
{
    [Foreign(7, 12)]
    public Airport? Airport { get; init; }

    /// <summary>
    /// <c>SID/STAR Route Identifier (SID/STAR IDENT)</c> or 
    /// <c>Approach Route Identifier (APPROACH IDENT)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.9 and 5.10.</remarks>
    [Field(14, 19)]
    public string Identifier { get; init; }

    /// <summary>
    /// <c>Route Type (RT TYPE)</c> character.
    /// </summary>
    /// <remarks>See paragraph 5.7.</remarks>
    [Character(20)]
    public char RouteType { get; init; }

    /// <summary>
    /// <c>Transition Identifier (TRANS IDENT)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.11.</remarks>
    [Field(21, 25)]
    public string TransitionIdentifier { get; init; }

    /// <summary>
    /// <c>Procedure Design Aircraft Category or Type</c> character.
    /// </summary>
    /// <remarks>See paragraph 5.301.</remarks>
    [Character(26)]
    public char AircraftCategory { get; init; }
}
