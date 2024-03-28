using Arinc.Spec424.Attributes;

namespace Arinc.Spec424.Records;

/// <summary>
/// <c>SID</c> primary record.
/// </summary>
/// <remarks>See section 4.1.9.1.</remarks>

[Record('P', 'D', subsectionIndex: 13)]
public class AirportInstrumentDeparture : Procedure;
