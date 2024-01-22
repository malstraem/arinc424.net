using System.Diagnostics;

using Arinc.Spec424.Attributes;
using Arinc.Spec424.Records.Subsequences;

namespace Arinc.Spec424.Records;

#pragma warning disable CS8618

/// <summary>
/// <c>Airport SID/STAR/Approach</c> primary record.
/// </summary>
/// <remarks>See paragraph 4.1.9.1.</remarks>
[Continuation(39), Sequenced(27, 29), DebuggerDisplay("{Identifier}")]
public abstract class Procedure : SequencedRecord424<ProcedurePoint>, IIdentity
{
    /// <summary>
    /// <c>Airport Identifier (ARPT)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.6.</remarks>
    [Field(7, 10)]
    [Link<AirportApproach, Airport>, Link<StandardTerminalArrival, Airport>, Link<StandardInstrumentDeparture, Airport>]
    public string AirportIdentifier { get; init; }

    /// <summary>
    /// <c>ICAO Code (ICAO CODE)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.14.</remarks>
    [Field(11, 12)]
    public string IcaoCode { get; init; }

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
