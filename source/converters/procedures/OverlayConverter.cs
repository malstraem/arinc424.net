using Arinc424.Procedures.Terms;

namespace Arinc424.Converters;

internal class OverlayConverter : ICharConverter<OverlayConverter, Overlay>
{
    public static Overlay Convert(char @char) => @char switch
    {
        '0' => Overlay.NotAuthorized,
        '1' => Overlay.Monitored,
        '2' => Overlay.NotMonitored,
        '3' => Overlay.Global,
        '4' => Overlay.FlightManagement,
        'A' => Overlay.AreaNavigation,
        'B' => Overlay.AreaNavigationVisual,
        'C' => Overlay.SatelliteAugmentNotPublished,
        'D' => Overlay.SatelliteAugmentFootprint,
        'P' => Overlay.StandAlone,
        'U' => Overlay.NotPublished,
        _ => Overlay.Unknown
    };
}
