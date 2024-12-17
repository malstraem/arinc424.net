using Arinc424.Processing;

namespace Arinc424.Airspace;

[Section('U', 'C')]

[Pipeline<ControlledConcatenate>]

[DebuggerDisplay($"{{{nameof(Icao)},nq}}, {{{nameof(Name)},nq}}")]
public class ControlledSpace : Space<ControlledVolume>;
