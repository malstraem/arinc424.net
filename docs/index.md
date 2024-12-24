> [!NOTE]
> The docs and API are a work in progress and will change as development progresses.

# Overview

While the **ARINC 424** specification describes entities with 132-byte fixed-length string, this library creates a database object model via building entities using reflection and runtime compilation.

Most terms are converted according to the specification into associated enumerations or numeric values ​​on the fly.

In addition, relationships between entities are established after the building stage.

In practice, this allows you to explore and manipulate the tree-like representation of **ARINC 424** database.

## Specification map

- [Grid MORA](api/Arinc424.OffrouteAltitude.yml)

# [Navaid](#tab/navaid)

- [VHF Navaid](api/Arinc424.Navigation.Omnidirectional.yml)
- [NDB Navaid](api/Arinc424.Navigation.Nondirectional.yml)
- [TACAN](api/Arinc424.Navigation.Tactical.yml)

# [Enroute](#tab/enroute)

- [Waypoint](api/Arinc424.Waypoints.Waypoint.yml)
- [Airway Markers](api/Arinc424.Routing.AirwayMarker.yml)
- [Holding Patterns](api/Arinc424.Routing.HoldingPattern.yml)
- [Airway](api/Arinc424.Routing.Airway.yml)
- [Special Activity Area](api/Arinc424.Routing.SpecialArea.yml)
- [Preferred Route](api/Arinc424.Routing.PreferredRoute.yml) 🚧
- Airway Restrictions
- [Communication](api/Arinc424.Comms.AirwayCommunication.yml)

# [Heliport](#tab/heliport)

- [Reference Point](api/Arinc424.Ground.Heliport.yml) 🚧
- [Terminal Waypoint](api/Arinc424.Waypoints.TerminalWaypoint.yml)
- [SID](api/Arinc424.Procedures.Departure.yml)/[STAR](api/Arinc424.Procedures.Arrival.yml)/[Approach](api/Arinc424.Procedures.Approach.yml)
- [Helipad](api/Arinc424.Ground.Helipad.yml)
- [TAA](api/Arinc424.Ground.ArrivalAltitude.yml)
- [MSA](api/Arinc424.Ground.MinimumAltitude.yml)
- [SBAS Path Point](api/Arinc424.Ground.SatellitePoint.yml)
- [Communication](api/Arinc424.Comms.PortCommunication.yml)

# [Airport](#tab/airport)

- [Reference Point](api/Arinc424.Ground.Airport.yml)
- [Gates](api/Arinc424.Ground.Gate.yml)
- [Terminal Waypoint](api/Arinc424.Waypoints.TerminalWaypoint.yml)
- [SID](api/Arinc424.Procedures.Departure.yml)/[STAR](api/Arinc424.Procedures.Arrival.yml)/[Approach](api/Arinc424.Procedures.Approach.yml)
- [Runways](api/Arinc424.Ground.Runway.yml)
- [Localizer/Glide Slope](api/Arinc424.Navigation.InstrumentLanding.yml)
- [TAA](api/Arinc424.Ground.ArrivalAltitude.yml)
- [MLS](api/Arinc424.Navigation.MicrowaveLanding.yml)
- [Localizer Marker](api/Arinc424.Navigation.InstrumentMarker.yml)
- [Terminal NDB](api/Arinc424.Navigation.TerminalBeacon.yml)
- [SBAS Path Point](api/Arinc424.Ground.SatellitePoint.yml)
- [GBAS Path Point](api/Arinc424.Ground.GroundPoint.yml)
- [Flight Planning](api/Arinc424.Ground.FlightPlan.yml) 🚧
- [MSA](api/Arinc424.Ground.MinimumAltitude.yml)
- [GLS Station](api/Arinc424.Navigation.GlobalLanding.yml)
- [Communications](api/Arinc424.Comms.PortCommunication.yml)

# [Company Routes](#tab/company)

- [Company Routes](api/Arinc424.Routing.CompanyRoute.yml) 🚧
- [Alternate Records](api/Arinc424.Routing.Alternate.yml) 🚧
- [Helicopter operation Routes](api/Arinc424.Routing.HelicopterCompanyRoute.yml) 🚧

# [Tables](#tab/tables)

- [Cruising Tables](api/Arinc424.Tables.CruiseTable.yml)
- [Geographical Reference](api/Arinc424.Tables.GeographicalReference.yml) 🚧
- [Communication Type](api/Arinc424.Tables.CommunicationType.yml) 🚧

# [Airspace](#tab/airspace)

- [Controlled](api/Arinc424.Airspace.ControlledSpace.yml)
- [FIR/UIR](api/Arinc424.Airspace.FlightRegion.yml)
- [Restrictive](api/Arinc424.Airspace.RestrictiveSpace.yml)

---
