namespace Arinc424.Navigation.Terms;

[Flags]
[Obsolete("need more section 5.93 analysis")]
public enum FacilityCharacteristics : uint
{
    Unknown = 0,
    Synchronous = 1,
    Asynchronous = 1 << 1,
    SyncUndefined = 1 << 2,
    Voice = 1 << 3,
    NoVoice = 1 << 4,
    VoiceUndefined = 1 << 5,
    Unmodulated = 1 << 6,
    CarrierKeyed = 1 << 7,
    ToneKeyed = 1 << 8,
    H400 = 1 << 9,
    H1020 = 1 << 10,
    Repeat1 = 1 << 11,
    Repeat2 = 1 << 12,
    Repeat3 = 1 << 13,
    Repeat4 = 1 << 14,
    Repeat5 = 1 << 15,
    Repeat6 = 1 << 16,
    Repeat7 = 1 << 17,
    Repeat8 = 1 << 18,
    Repeat9 = 1 << 19,
    CollocatedLocalizer = 1 << 20,
    CollocatedGlideSlope = 1 << 21,
    NotCollocatedLocalizerGlideSlope = 1 << 22,
    Usable = 1 << 23,
    Unusable = 1 << 24,
    Restricted = 1 << 25,
    UseUndefined = 1 << 26,
    CollocatedAzimuth = 1 << 27,
    CollocatedElevation = 1 << 28,
    NotCollocatedAzimuthElevation = 1 << 29,
    HighRateApproachAzimuth = 1 << 30
}
