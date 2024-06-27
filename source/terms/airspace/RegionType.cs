namespace Arinc424.Airspace.Terms;

/// <summary>
/// <c>FIR/UIR Indicator (IND)</c> character.
/// </summary>
/// <remarks>See section 5.117.</remarks>
[Flags, Transform<RegionTypeConverter, RegionType>]
public enum RegionType : byte
{
    Unknown = 0,
    FlightInfo = 1,
    UpperInfo = 1 << 1
}
