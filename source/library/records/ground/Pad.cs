namespace Arinc424.Ground;

/**<summary>
<c>Helipad</c> primary record.
</summary>*/
[Obsolete("todo: describe supplement v21+")]

[Section('H', 'H', subIndex: 13), Section('P', 'H', subIndex: 13)]

[DebuggerDisplay($"{{{nameof(Identifier)},nq}}, {nameof(Port)} - {{{nameof(Port)}}}")]
public class Pad : Touch
{
    public Port Port { get; set; }
}
