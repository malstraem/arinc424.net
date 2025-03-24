namespace Arinc424.Airspace;

/// <summary>Base space properties.</summary>
[Continuous(25)]
public abstract class Space<TVolume> : Record424<TVolume>, IIcao, INamed where TVolume : Volume
{
    [Field(7, 8)]
    public Icao Icao { get; set; }

    /**<summary>
    <c>Restrictive Airspace Name</c> for <see cref="RestrictiveSpace"/> and
    <c>Controlled Airspace Name (ARSP NAME)</c> for <see cref="ControlledSpace"/> field.
    </summary>
    <remarks>See section 5.126 and 5.216.</remarks>*/
    [Field(94, 123)]
    public string? Name { get; set; }
}
