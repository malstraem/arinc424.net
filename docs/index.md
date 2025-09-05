# Overview

> [!NOTE]
> The docs and API are a work in progress and will change as development progresses.

While the **ARINC 424** specification describes entities with 132-byte fixed-length string, this library creates a database object model via building entities using reflection and runtime compilation.

- Most terms are converted according to the specification into associated enumerations or numeric values ​​on the fly.

- Relationships between entities are established after the building stage.

In practice, this allows you read the tree-like representation of **ARINC 424** database.

## Specification map

- [Grid MORA](api/Arinc424.Offroute.yml)

# [Airspace](#tab/airspace)

- [FIR/UIR](api/Arinc424.Airspace.FlightRegion.yml)
- [Controlled](api/Arinc424.Airspace.ControlledSpace.yml)
- [Restrictive](api/Arinc424.Airspace.RestrictiveSpace.yml)

# [Navaid](#tab/navaid)

- [TACAN](api/Arinc424.Navigation.Tactical.yml)
- [VHF](api/Arinc424.Navigation.Omnidirect.yml)
- [NDB](api/Arinc424.Navigation.Nondirect.yml)

# [Enroute](#tab/enroute)

- [Airway](api/Arinc424.Routing.Airway.yml)
- [Waypoint](api/Arinc424.Waypoints.Waypoint.yml)
- [Airway Marker](api/Arinc424.Routing.AirwayMarker.yml)
- [Holding Pattern](api/Arinc424.Routing.HoldingPattern.yml)
- [Special Activity Area](api/Arinc424.Routing.SpecialArea.yml)
- [Communication](api/Arinc424.Comms.AirwayCommunication.yml)
- [Preferred Route](api/Arinc424.Routing.PreferredRoute.yml) 🚧
- Airway Restrictions (not started)

# [Airport](#tab/airport)

- [Reference Point](api/Arinc424.Ground.Airport.yml)
- [Terminal Waypoint](api/Arinc424.Waypoints.TerminalWaypoint.yml)
- [Runway Threshold](api/Arinc424.Ground.Threshold.yml)
- [Gate](api/Arinc424.Ground.Gate.yml)
- [SID](api/Arinc424.Procedures.Departure.yml), [STAR](api/Arinc424.Procedures.Arrival.yml), [Approach](api/Arinc424.Procedures.Approach.yml)
- [TAA](api/Arinc424.Ground.ArrivalAltitude.yml), [MSA](api/Arinc424.Ground.MinimumAltitude.yml)
- [SBAS](api/Arinc424.Ground.SatellitePoint.yml), [GBAS](api/Arinc424.Ground.GroundPoint.yml)
- [ILS](api/Arinc424.Navigation.InstrumentLanding.yml), [GLS](api/Arinc424.Navigation.GlobalLanding.yml), [MLS](api/Arinc424.Navigation.MicrowaveLanding.yml)
- [Localizer Marker](api/Arinc424.Navigation.InstrumentMarker.yml)
- [Terminal NDB](api/Arinc424.Navigation.TerminalBeacon.yml)
- [Communication](api/Arinc424.Comms.PortCommunication.yml)
- [Flight Plan](api/Arinc424.Ground.FlightPlan.yml) 🚧

# [Heliport](#tab/heliport)

- [Reference Point](api/Arinc424.Ground.Heliport.yml) 🚧
- [Terminal Waypoint](api/Arinc424.Waypoints.TerminalWaypoint.yml)
- [Helipad](api/Arinc424.Ground.Helipad.yml)

# [Company Routes](#tab/company)

- [Company Route](api/Arinc424.Routing.CompanyRoute.yml) 🚧
- [Alternate Record](api/Arinc424.Routing.Alternate.yml) 🚧
- [Helicopter Operation Route](api/Arinc424.Routing.HelicopterCompanyRoute.yml) 🚧

# [Tables](#tab/tables)

- [Cruising Table](api/Arinc424.Tables.CruiseTable.yml)
- [Geographical Reference](api/Arinc424.Tables.GeographicalReference.yml) 🚧
- [Communication Type](api/Arinc424.Tables.CommunicationType.yml) 🚧

---
