using Arinc424.Navigation.Terms;

namespace Arinc424.Converters;

[Obsolete("need more section 5.93 analysis")]
internal abstract class FacilityCharacteristicsConverter : IStringConverter<FacilityCharacteristicsConverter, FacilityCharacteristics>
{
    public static FacilityCharacteristics Convert(ReadOnlySpan<char> @string) => @string[0] switch
    {
        'S' => FacilityCharacteristics.Synchronous,
        'A' => FacilityCharacteristics.Asynchronous,
        'U' => FacilityCharacteristics.SyncUndefined,
        _ => FacilityCharacteristics.Unknown,

    }
    | @string[1] switch
    {
        'Y' => FacilityCharacteristics.Voice,
        'N' => FacilityCharacteristics.NoVoice,
        'U' => FacilityCharacteristics.VoiceUndefined,
        _ => FacilityCharacteristics.Unknown
    }
    | @string[2] switch
    {
        '0' => FacilityCharacteristics.Unmodulated,
        '1' => FacilityCharacteristics.CarrierKeyed,
        '2' => FacilityCharacteristics.ToneKeyed,
        _ => FacilityCharacteristics.Unknown
    }
    | @string[3] switch
    {
        '4' => FacilityCharacteristics.H400,
        '1' => FacilityCharacteristics.H1020,
        'Y' => FacilityCharacteristics.Usable,
        'N' => FacilityCharacteristics.Unusable,
        'R' => FacilityCharacteristics.Restricted,
        'U' => FacilityCharacteristics.UseUndefined,
        'H' => FacilityCharacteristics.HighRateApproachAzimuth,
        _ => FacilityCharacteristics.Unknown
    }
    | @string[4] switch
    {
        '1' => FacilityCharacteristics.Repeat1,
        '2' => FacilityCharacteristics.Repeat2,
        '3' => FacilityCharacteristics.Repeat3,
        '4' => FacilityCharacteristics.Repeat4,
        '5' => FacilityCharacteristics.Repeat5,
        '6' => FacilityCharacteristics.Repeat6,
        '7' => FacilityCharacteristics.Repeat7,
        '8' => FacilityCharacteristics.Repeat8,
        '9' => FacilityCharacteristics.Repeat9,
        'L' => FacilityCharacteristics.CollocatedLocalizer,
        'G' => FacilityCharacteristics.CollocatedGlideSlope,
        _ when char.IsWhiteSpace(@string[4]) => FacilityCharacteristics.NotCollocatedAzimuthElevation,
        'A' => FacilityCharacteristics.CollocatedAzimuth,
    };
}
