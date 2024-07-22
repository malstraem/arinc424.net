namespace Arinc424.Navigation.Terms;

[Flags]
[Obsolete("need more section 5.93 analysis")]
public enum FacilityCharacteristics : uint
{
    Unknown = 0u,
    Synchronous = 1u,
    Asynchronous = 1u << 1,
    SyncUndefined = 1u << 2,
    Voice = 1u << 3,
    NoVoice = 1u << 4,
    VoiceUndefined = 1u << 5,
    Unmodulated = 1u << 6,
    CarrierKeyed = 1u << 7,
    ToneKeyed = 1u << 8,
    H400 = 1u << 9,
    H1020 = 1u << 10,
    Repeat1 = 1u << 11,
    Repeat2 = 1u << 12,
    Repeat3 = 1u << 13,
    Repeat4 = 1u << 14,
    Repeat5 = 1u << 15,
    Repeat6 = 1u << 16,
    Repeat7 = 1u << 17,
    Repeat8 = 1u << 18,
    Repeat9 = 1u << 19,
    CollocatedLocalizer = 1u << 20,
    CollocatedGlideSlope = 1u << 21,
    NotCollocatedLocalizerGlideSlope = 1u << 22,
    Usable = 1u << 23,
    Unusable = 1u << 24,
    Restricted = 1u << 25,
    UseUndefined = 1u << 26,
    CollocatedAzimuth = 1u << 27,
    CollocatedElevation = 1u << 28,
    NotCollocatedAzimuthElevation = 1u << 29,
    HighRateApproachAzimuth = 1u << 30
}
