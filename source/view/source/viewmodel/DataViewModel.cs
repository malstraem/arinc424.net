using Avalonia.Platform.Storage;

namespace Arinc424.ViewModel;

using View;
using Model;

public partial class DataViewModel : ObservableObject
{
    [ObservableProperty]
    public partial bool IsLoading { get; set; }

    [ObservableProperty]
    public partial SectionModel? Selected { get; set; }

    [ObservableProperty]
    public partial IEnumerable<SectionModel>? Sections { get; set; }

    [ObservableProperty]
    public partial bool IsEmpty { get; set; } = true;

    [Obsolete("todo and add i18n resources")]
    private static IEnumerable<SectionModel> GetSections(Data424 data) =>
    [
        new("Navaid",
        [
            data.Omnidirects.GetViewModel("VHF"),
            data.Nondirects.GetViewModel("NDB"),
            data.Tacticals.GetViewModel("TACAN")
        ]),
        new("Enroute",
        [
            data.EnrouteWaypoints.GetViewModel("Waypoint"),
            data.AirwayMarkers.GetViewModel("Marker"),
            data.HoldingPatterns.GetViewModel("Holding Pattern"),
            data.Airways.GetViewModel("Airway"),
            data.SpecialAreas.GetViewModel("Special Area"),
            data.PreferredRoutes.GetViewModel("Preferred Route"),
            data.AirwayCommunications.GetViewModel("Communication")
        ]),
        new("Heliport",
        [
            data.Heliports.GetViewModel("Reference Point"),
            data.HeliportTerminalWaypoints.GetViewModel("Terminal Waypoint"),
            data.HeliportDepartures.GetViewModel("SID"),
            data.HeliportArrivals.GetViewModel("STAR"),
            data.HeliportApproaches.GetViewModel("Approach"),
            data.HeliportSatellitePoints.GetViewModel("SBAS"),
            data.HeliportArrivalAltitudes.GetViewModel("TAA"),
            data.HeliportMinimumAltitudes.GetViewModel("MSA"),
            data.HeliportCommunications.GetViewModel("Communication")
        ]),
        new("Airport",
        [
            data.Airports.GetViewModel("Reference Point"),
            data.Gates.GetViewModel("Gate"),
            data.Thresholds.GetViewModel("Thresholds"),
            data.AirportTerminalWaypoints.GetViewModel("Terminal Waypoint"),
            data.AirportDepartures.GetViewModel("SID"),
            data.AirportArrivals.GetViewModel("STAR"),
            data.AirportApproaches.GetViewModel("Approach"),
            data.InstrumentLandings.GetViewModel("Localizer/Glideslope"),
            data.InstrumentMarkers.GetViewModel("Localizer Marker"),
            data.TerminalBeacons.GetViewModel("Terminal NDB"),
            data.MicrowaveLandings.GetViewModel("MLS"),
            data.GlobalLandings.GetViewModel("GLS"),
            data.AirportSatellitePoints.GetViewModel("SBAS"),
            data.GroundPoints.GetViewModel("GBAS"),
            data.AirportArrivalAltitudes.GetViewModel("TAA"),
            data.AirportMinimumAltitudes.GetViewModel("MSA"),
            data.AirportCommunications.GetViewModel("Communication")
        ]),
        new("Airspace",
        [
            data.FlightRegions.GetViewModel("FIR/UIR"),
            data.ControlledSpaces.GetViewModel("Controlled"),
            data.RestrictedSpaces.GetViewModel("Restrictive")
        ])
    ];

    [Obsolete("hardcoded")]
    public async void Load(IStorageItem[] items)
    {
        IsEmpty = false;
        IsLoading = true;

        var data = await Task.Run(() =>
        {
            string[] strings = File.ReadAllLines(Uri.UnescapeDataString(items.First().Path.AbsolutePath));

            return Data424.Create(Meta424.Create(Supplement.V18), strings, out var _, out var _);
        });

        Sections = await Task.Run(() => GetSections(data));

        IsLoading = false;
    }
}
