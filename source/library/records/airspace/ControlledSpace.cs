namespace Arinc424.Airspace;

[Section('U', 'C')]
[DebuggerDisplay($"{{{nameof(IcaoCode)},nq}}, {{{nameof(Name)},nq}}")]
public class ControlledSpace : Space<ControlledVolume>;
