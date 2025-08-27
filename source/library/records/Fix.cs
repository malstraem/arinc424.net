namespace Arinc424;

using Ground;
using Routing;
using Waypoints;
using Navigation;

/**<summary>
Base object with an identifier that can be used as a navigation point.
</summary>*/
public abstract class Fix : Geo, IIcao, IIdentity
{
    [Field(11, 12)]
    [Field<Waypoint>(20, 21)]
    [Field<SpecialArea>(14, 15)]
    [Field<AirwayMarker>(20, 21)]
    [Field<Nondirect>(20, 21)]
    [Field<Omnidirect>(20, 21)]
    public Icao Icao { get; set; }

    /**<summary>
    <para>
      <c>Airport/Heliport Identifier (ARPT/HELI IDENT)</c> field for <see cref="Airport"/> and <see cref="Heliport"/>. See section 5.6.
    </para>
    <para>
      <c>Fix Identifier (FIX IDENT)</c> field for <see cref="TerminalWaypoint"/> and <see cref="Waypoint"/>. See section 5.13.
    </para>
    <para>
      <c>VOR/NDB Identifier (VOR IDENT/NDB IDENT)</c> field for <see cref="Omnidirect"/>,
      <see cref="Nondirect"/> and <see cref="Tactical"/>. See section 5.33.
    </para>
    <para>
      <c>Localizer/MLS/GLS Identifier (LOC, MLS, GLS IDENT)</c> field for <see cref="InstrumentLanding"/>, <see cref="InstrumentMarker"/>,
      <see cref="MicrowaveLanding"/> and <see cref="GlobalLanding"/>. See section 5.44.
    </para>
    <para>
      <c>Runway Identifier (RUNWAY ID)</c> field for <see cref="Threshold"/>. See section 5.46.
    </para>
    <para>
      <c>Gate Identifier (GATE IDENT)</c> field for <see cref="Gate"/>. See section 5.56.
    </para>
    <para>
      <c>Marker Identifier (MARKER IDENT)</c> field for <see cref="AirwayMarker"/>. See section 5.110.
    </para>
    <para>
      <c>Reference Path Identifier (REF ID)</c> field for <see cref="GroundPoint"/> and <see cref="SatellitePoint"/>. See section 5.257.
    </para>
    <para>
      <c>Activity Identifier</c> field for <see cref="SpecialArea"/>. See section 5.279.
    </para>
    </summary>*/
    [Field(14, 17)]
    [Field<Port>(7, 10)]
    [Field<Gate>(14, 18)]
    [Field<Waypoint>(14, 18)]
    [Field<PathPoint>(33, 36)]
    [Field<SpecialArea>(8, 13)]
    [Field<Threshold>(14, 18)]
    public string Identifier { get; set; }
}
