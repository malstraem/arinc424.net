using Arinc.Spec424.Attributes;

namespace Arinc.Spec424.Records;

/// <summary>
/// <c>STAR</c> primary record.
/// </summary>
/// <remarks>See paragraph 4.1.9.1.</remarks>
[Record('P', 'E', subsectionIndex: 13)]
public class AirportTerminalArrival : Procedure;
