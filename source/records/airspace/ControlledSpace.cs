namespace Arinc424.Airspace;

[DebuggerDisplay($"{{{nameof(IcaoCode)},nq}}, {{{nameof(Name)},nq}}")]
public class ControlledSpace : Space<ControlledVolume>;
