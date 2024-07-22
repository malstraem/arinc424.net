namespace Arinc424.Airspace;

[Section('U', 'R')]
[DebuggerDisplay($"{{{nameof(IcaoCode)},nq}}, {{{nameof(Designation)},nq}}")]
public class RestrictiveSpace : Space<RestrictiveVolume>
{
    /// <inheritdoc cref="RestrictiveVolume.Designation"/>
    public string Designation { get; set; }
}
