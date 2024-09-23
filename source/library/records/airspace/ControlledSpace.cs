namespace Arinc424.Airspace;

[Section('U', 'C')]
[DebuggerDisplay($"{{{nameof(Icao)},nq}}, {{{nameof(Name)},nq}}")]
public class ControlledSpace : Space<ControlledVolume>, INamed
{
    /// <summary>
    /// <c>Controlled Airspace Name (ARSP NAME)</c> field.
    /// </summary>
    /// <remarks>See section 5.216.</remarks>
    [Field(94, 123)]
    public string? Name { get; set; }
}
