using System.Reflection;

namespace Arinc424;

using Comms;
using Ground;
using Tables;
using Routing;
using Airspace;
using Waypoints;
using Procedures;
using Navigation;

/**<summary>
<c>ARINC 424</c> database representation.
</summary>*/
public class Data424
{
    internal static Dictionary<PropertyInfo, Section> GetProperties()
    {
        Dictionary<PropertyInfo, Section> properties = [];

        foreach (var property in typeof(Data424).GetProperties())
            properties.Add(property, property.GetCustomAttribute<SectionAttribute>()!.Value);

        return properties;
    }

    public static Data424 Create(Meta424 meta, IEnumerable<string> strings, out string[] skipped, out Invalid invalid)
        => new Parser424(meta).Parse(strings, out skipped, out invalid);

    /**<summary>
    <c>Grid MORA</c> records.
    </summary>
    <remarks>Section <c>AS</c>.</remarks>*/
    [Section('A', 'S')]
    public Offroute[] Offroute { get; set; } = [];

    #region Navaid
    /**<summary>
    <c>TACAN-Only Navaid</c> records.
    </summary>
    <remarks>Section <c>DT</c>.</remarks>*/
    [Section('D', 'T')]
    public Tactical[] Tacticals { get; set; } = [];

    /**<summary>
    <c>NDB Navaid</c> records.
    </summary>
    <remarks>Section <c>DB</c>.</remarks>*/
    [Section('D', 'B')]
    public Nondirect[] Nondirectionals { get; set; } = [];

    /**<summary>
    <c>VHF Navaid</c> records.
    </summary>
    <remarks>Section <c>D</c>.</remarks>*/
    [Section('D')]
    public Omnidirect[] Omnidirectionals { get; set; } = [];
    #endregion

    #region Enroute
    /**<summary>
    <c>Enroute Airway</c> records.
    </summary>
    <remarks>Section <c>ER</c>.</remarks>*/
    [Section('E', 'R')]
    public Airway[] Airways { get; set; } = [];

    /**<summary>
    <c>Enroute Waypoint</c> records.
    </summary>
    <remarks>Section <c>EA</c>.</remarks>*/
    [Section('E', 'A')]
    public Waypoint[] EnrouteWaypoints { get; set; } = [];

    /**<summary>
    <c>Enroute Airway Marker</c> records.
    </summary>
    <remarks>Section <c>EM</c>.</remarks>*/
    [Section('E', 'M')]
    public AirwayMarker[] AirwayMarkers { get; set; } = [];

    /**<summary>
    <c>Holding Pattern</c> records.
    </summary>
    <remarks>Section <c>EP</c>.</remarks>*/
    [Section('E', 'P')]
    public HoldingPattern[] HoldingPatterns { get; set; } = [];

    /**<summary>
    <c>Preferred Route</c> records.
    </summary>
    <remarks>Section <c>ET</c>.</remarks>*/
    [Section('E', 'T')]
    public PreferredRoute[] PreferredRoutes { get; set; } = [];

    /**<summary>
    <c>Special Activity Area</c> records.
    </summary>
    <remarks>Section <c>ES</c>.</remarks>*/
    [Section('E', 'S')]
    public SpecialArea[] SpecialAreas { get; set; } = [];

    /**<summary>
    <c>Enroute Airway Communication</c> records.
    </summary>
    <remarks>Section <c>EV</c>.</remarks>*/
    [Section('E', 'V')]
    public AirwayCommunication[] AirwayCommunications { get; set; } = [];
    #endregion

    #region Heliport
    /**<summary>
    <c>Heliport</c> records.
    </summary>
    <remarks>Section <c>HA</c>.</remarks>*/
    [Section('H', 'A')]
    public Heliport[] Heliports { get; set; } = [];

    /**<summary>
    <c>Heliport STAR</c> records.
    </summary>
    <remarks>Section <c>HE</c>.</remarks>*/
    [Section('H', 'E')]
    public Arrival[] HeliportArrivals { get; set; } = [];

    /**<summary>
    <c>Heliport Approaches</c> records.
    </summary>
    <remarks>Section <c>HF</c>.</remarks>*/
    [Section('H', 'F')]
    public Approach[] HeliportApproaches { get; set; } = [];

    /**<summary>
    <c>Heliport SID</c> records.
    </summary>
    <remarks>Section <c>HD</c>.</remarks>*/
    [Section('H', 'D')]
    public Departure[] HeliportDepartures { get; set; } = [];

    /**<summary>
    <c>Heliport SID</c> records.
    </summary>
    <remarks>Section <c>HP</c>.</remarks>*/
    [Section('H', 'P')]
    public SatellitePoint[] HeliportSatellitePoints { get; set; } = [];

    /**<summary>
    <c>Heliport TAA</c> records.
    </summary>
    <remarks>Section <c>HK</c>.</remarks>*/
    [Section('H', 'K')]
    public ArrivalAltitude[] HeliportArrivalAltitudes { get; set; } = [];

    /**<summary>
    <c>Heliport MSA</c> records.
    </summary>
    <remarks>Section <c>HS</c>.</remarks>*/
    [Section('H', 'S')]
    public MinimumAltitude[] HeliportMinimumAltitudes { get; set; } = [];

    /**<summary>
    <c>Heliport Communication</c> records.
    </summary>
    <remarks>Section <c>HV</c>.</remarks>*/
    [Section('H', 'V')]
    public PortCommunication[] HeliportCommunications { get; set; } = [];

    /**<summary>
    <c>Heliport Terminal Waypoint</c> records.
    </summary>
    <remarks>Section <c>HC</c>.</remarks>*/
    [Section('H', 'C')]
    public TerminalWaypoint[] HeliportTerminalWaypoints { get; set; } = [];
    #endregion

    #region Airport
    /**<summary>
    <c>Gate</c> records.
    </summary>
    <remarks>Section <c>PB</c>.</remarks>*/
    [Section('P', 'B')]
    public Gate[] Gates { get; set; } = [];

    /**<summary>
    <c>Pad</c> records.
    </summary>
    <remarks>Section <c>PH</c>.</remarks>*/
    [Section('P', 'H')]
    public Pad[] AirportPads { get; set; } = [];

    /**<summary>
    <c>Runway</c> records.
    </summary>
    <remarks>Section <c>PG</c>.</remarks>*/
    [Section('P', 'G')]
    public Threshold[] Thresholds { get; set; } = [];

    /**<summary>
    <c>Airport</c> records.
    </summary>
    <remarks>Section <c>PA</c>.</remarks>*/
    [Section('P', 'A')]
    public Airport[] Airports { get; set; } = [];

    /**<summary>
    <c>Flight Planning</c> records.
    </summary>
    <remarks>Section <c>PR</c>.</remarks>*/
    [Section('P', 'R')]
    public FlightPlan[] FlightPlans { get; set; } = [];

    /**<summary>
    <c>Airport STAR</c> records.
    </summary>
    <remarks>Section <c>PE</c>.</remarks>*/
    [Section('P', 'E')]
    public Arrival[] AirportArrivals { get; set; } = [];

    /**<summary>
    <c>Airport Approach</c> records.
    </summary>
    <remarks>Section <c>PF</c>.</remarks>*/
    [Section('P', 'F')]
    public Approach[] AirportApproaches { get; set; } = [];

    /**<summary>
    <c>Airport SID</c> records.
    </summary>
    <remarks>Section <c>PD</c>.</remarks>*/
    [Section('P', 'D')]
    public Departure[] AirportDepartures { get; set; } = [];

    /**<summary>
    <c>Terminal NDB</c> records.
    </summary>
    <remarks>Section <c>PN</c>.</remarks>*/
    [Section('P', 'N')]
    public TerminalBeacon[] TerminalBeacons { get; set; } = [];

    /**<summary>
    <c>GBAS Path Point</c> records.
    </summary>
    <remarks>Section <c>PQ</c>.</remarks>*/
    [Section('P', 'Q')]
    public GroundPoint[] GroundPoints { get; set; } = [];

    /**<summary>
    <c>SBAS Path Point</c> records.
    </summary>
    <remarks>Section <c>PP</c>.</remarks>*/
    [Section('P', 'P')]
    public SatellitePoint[] AirportSatellitePoints { get; set; } = [];

    /**<summary>
    <c>Airport Communication</c> records.
    </summary>
    <remarks>Section <c>PV</c>.</remarks>*/
    [Section('P', 'V')]
    public PortCommunication[] AirportCommunications { get; set; } = [];

    /**<summary>
    <c>Airport TAA</c> records.
    </summary>
    <remarks>Section <c>PK</c>.</remarks>*/
    [Section('P', 'K')]
    public ArrivalAltitude[] AirportArrivalAltitudes { get; set; } = [];

    /**<summary>
    <c>Airport MSA</c> records.
    </summary>
    <remarks>Section <c>PS</c>.</remarks>*/
    [Section('P', 'S')]
    public MinimumAltitude[] AirportMinimumAltitudes { get; set; } = [];

    /**<summary>
    <c>Airport Terminal Waypoint</c> records.
    </summary>
    <remarks>Section <c>PC</c>.</remarks>*/
    [Section('P', 'C')]
    public TerminalWaypoint[] AirportTerminalWaypoints { get; set; } = [];

    /**<summary>
    <c>GLS</c> records.
    </summary>
    <remarks>Section <c>PT</c>.</remarks>*/
    [Section('P', 'T')]
    public GlobalLanding[] GlobalLandings { get; set; } = [];

    /**<summary>
    <c>Airport and Heliport MLS</c> records.
    </summary>
    <remarks>Section <c>PL</c>.</remarks>*/
    [Section('P', 'L')]
    public MicrowaveLanding[] MicrowaveLandings { get; set; } = [];

    /**<summary>
    <c>Airport and Heliport Localizer and Glide Slope</c> records.
    </summary>
    <remarks>Section <c>PI</c>.</remarks>*/
    [Section('P', 'I')]
    public InstrumentLanding[] InstrumentLandings { get; set; } = [];

    /**<summary>
    <c>Airport and Heliport Localizer Marker</c> records.
    </summary>
    <remarks>Section <c>PM</c>.</remarks>*/
    [Section('P', 'M')]
    public InstrumentMarker[] InstrumentMarkers { get; set; } = [];
    #endregion

    #region Company Routes
    /**<summary>
    <c>Alternate</c> records.
    </summary>
    <remarks>Section <c>RA</c>.</remarks>*/
    [Section('R', 'A')]
    public Alternate[] Alternates { get; set; } = [];

    /**<summary>
    <c>Company Route</c> records.
    </summary>
    <remarks>Section <c>R</c>.</remarks>*/
    [Section('R')]
    public CompanyRoute[] CompanyRoutes { get; set; } = [];

    /**<summary>
    <c>Helicopter Operations Company Route</c> records.
    </summary>
    <remarks>Section <c>RH</c>.</remarks>*/
    [Section('R', 'H')]
    public HelicopterCompanyRoute[] HelicopterCompanyRoutes { get; set; } = [];
    #endregion

    #region Tables
    /**<summary>
    <c>Cruising Table</c> records.
    </summary>
    <remarks>Section <c>TC</c>.</remarks>*/
    [Section('T', 'C')]
    public CruiseTable[] CruisingTables { get; set; } = [];

    /**<summary>
    <c>Communication Type Translation</c> records.
    </summary>
    <remarks>Section <c>TV</c>.</remarks>*/
    [Section('T', 'V')]
    public CommunicationType[] CommunicationTypes { get; set; } = [];

    /**<summary>
    <c>Geographical Reference Table</c> records.
    </summary>
    <remarks>Section <c>TG</c>.</remarks>*/
    [Section('T', 'G')]
    public GeographicalReference[] GeographicalReferences { get; set; } = [];
    #endregion

    #region Airspace
    /**<summary>
    <c>FIR/UIR</c> records.
    </summary>
    <remarks>Section <c>UF</c>.</remarks>*/
    [Section('U', 'F')]
    public FlightRegion[] FlightRegions { get; set; } = [];

    /**<summary>
    <c>Controlled Airspace</c> records.
    </summary>
    <remarks>Section <c>UC</c>.</remarks>*/
    [Section('U', 'C')]
    public ControlledSpace[] ControlledSpaces { get; set; } = [];

    /**<summary>
    <c>Restrictive Airspace</c> records.
    </summary>
    <remarks>Section <c>UR</c>.</remarks>*/
    [Section('U', 'R')]
    public RestrictiveSpace[] RestrictiveSpaces { get; set; } = [];
    #endregion
}
