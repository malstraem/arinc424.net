namespace Arinc424.Routing;

/// <summary>
/// <c>Enroute Airways</c> primary record sequence.
/// </summary>
/// <remarks>See section 4.1.6.1.</remarks>
[Section('E', 'R'), Continuous(39), Sequenced(26, 29)]
[DebuggerDisplay($"{{{nameof(Identifier)}}}")]
public class Airway : Record424<AirwayPoint>, IIdentity
{
    /// <include file='Comments.xml' path="doc/member[@name='Route']/*"/>
    [Field(14, 18)]
    public string Identifier { get; set; }
}
