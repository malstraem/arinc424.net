using Arinc424.Navigation;
using Arinc424.Ports;
using Arinc424.Routing;
using Arinc424.Waypoints;

namespace Arinc424;

public abstract class Fix : Geo, IIdentity
{
    /// <summary>
    /// <para>
    ///   <c>Airport/Heliport Identifier (ARPT/HELI IDENT)</c> field for <see cref="Airport"/> and <see cref="Heliport"/>. See section 5.6.
    /// </para>
    /// <para>
    ///   <c>Fix Identifier (FIX IDENT)</c> field for <see cref="TerminalWaypoint"/> and <see cref="Waypoint"/>. See section 5.13.
    /// </para>
    /// <para>
    ///   <c>VOR/NDB Identifier (VOR IDENT/NDB IDENT)</c> field for <see cref="Omnidirectional"/> and <see cref="Nondirectional"/>. See section 5.33.
    /// </para>
    /// <para>
    ///   <c>Localizer/MLS/GLS Identifier (LOC, MLS, GLS IDENT)</c> field for <see cref="InstrumentLanding"/>, <see cref="InstrumentMarker"/>,
    ///   <see cref="MicrowaveLanding"/> and <see cref="GlobalLanding"/>. See section 5.44.
    /// </para>
    /// <para>
    ///   <c>Runway Identifier (RUNWAY ID)</c> field for <see cref="Runway"/>. See section 5.46.
    /// </para>
    /// <para>
    ///   <c>Marker Identifier (MARKER IDENT)</c> field for <see cref="AirwayMarker"/>. See section 5.110.
    /// </para>
    /// <para>
    ///   <c>Reference Path Identifier (REF ID)</c> field for <see cref="GroundPoint"/> and <see cref="SatellitePoint"/>. See section 5.257.
    /// </para>
    /// </summary>
    [Field(14, 17)]
    [Field<Port>(7, 10)]
    [Field<Runway>(14, 18)]
    [Field<Waypoint>(14, 18)]
    [Field<PathPoint>(33, 36)]
    public string Identifier { get; set; }
}
