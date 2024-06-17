> [!NOTE]
> The docs and API are a work in progress and will change as development progresses.

# Overview

While the **`ARINC 424`** specification describes entities (*or records*) with 132-byte fixed-length string, this library creates 
a database object model at load time via building entities using reflection. Most terms are converted according 
to the specification into associated enums or numeric values on the fly.

In addition, relationships between entities are established after the building stage.

In practice, this allows you to explore and manipulate the tree-like representation of **`ARINC 424`** database.

## Specification map

- [Grid MORA](api/Arinc424.OffrouteAltitude.yml) 🚧

# [Airport](#tab/airport)
- [Reference Points](api/Arinc424.Ports.Airport.yml) ✔️
- [Gates](api/Arinc424.Ports.Gate.yml) ✔️
- [Terminal Waypoints](api/Arinc424.Waypoints.AirportTerminalWaypoint.yml) ✔️
- [SID](api/Arinc424.Procedures.AirportDeparture.yml)/[STAR](api/Arinc424.Procedures.AirportArrival.yml)/[Approach](api/Arinc424.Procedures.AirportApproach.yml) ✔️
- [Runways](api/Arinc424.Ports.Runway.yml) ✔️
- [Localizer/Glide Slope](api/Arinc424.Navigation.InstrumentLandingSystem.yml) ✔️
- [TAA](api/Arinc424.Ports.AirportArrivalAltitudes.yml) ✔️
- [MLS](api/Arinc424.Navigation.MicrowaveLandingSystem.yml) ✔️
- [Localizer Marker](api/Arinc424.Navigation.InstrumentLandingMarker.yml) ✔️
- [Terminal NDB](api/Arinc424.Navigation.AirportBeacon.yml) ✔️
- [SBAS Path Point](api/Arinc424.Ports.AirportSatellitePoint.yml) ✔️
- [GBAS Path Point](api/Arinc424.Ports.GroundPoint.yml) ✔️
- [Flight Planning](api/Arinc424.Ports.FlightPlanning.yml) 🚧
- [MSA](api/Arinc424.Ports.AirportMinimumAltitudes.yml) ✔️
- [GLS Station](api/Arinc424.Navigation.GlobalLandingSystem.yml) ✔️
- [Communications](api/Arinc424.Comms.AirportCommunications.yml) ✔️

# [Heliport](#tab/heliport)
- [Pads](api/Arinc424.Ports.Heliport.yml) 🚧
- [Terminal Waypoints](api/Arinc424.Waypoints.HeliportTerminalWaypoint.yml) 🚧
- [SID](api/Arinc424.Procedures.HeliportDeparture.yml)/[STAR](api/Arinc424.Procedures.HeliportArrival.yml)/[Approach](api/Arinc424.Procedures.HeliportApproach.yml) 🚧
- [TAA](api/Arinc424.Ports.HeliportArrivalAltitudes.yml) 🚧
- [MSA](api/Arinc424.Ports.HeliportMinimumAltitudes.yml) 🚧
- [SBAS Path Point](api/Arinc424.Ports.HelicopterSatellitePoint.yml) 🚧
- [Communications](api/Arinc424.Comms.HeliportCommunications.yml) 🚧

# [Enroute](#tab/enroute)
- [Waypoints](api/Arinc424.Waypoints.Waypoint.yml) ✔️
- [Airway Markers](api/Arinc424.Routing.AirwayMarker.yml) ✔️
- [Holding Patterns](api/Arinc424.Routing.HoldingPattern.yml) ✔️
- [Airways and Routes](api/Arinc424.Routing.Airway.yml) ✔️
- [Special Activity Areas](api/Arinc424.Routing.SpecialActivityArea.yml) ✔️
- [Preferred Routes](api/Arinc424.Routing.PreferredRoute.yml) 🚧
- Airway Restrictions
- [Communications](api/Arinc424.Comms.AirwayCommunications.yml) ✔️

# [Navaid](#tab/navaid)
- [VHF Navaid](api/Arinc424.Navigation.Omnidirectional.yml) ✔️
- [NDB Navaid](api/Arinc424.Navigation.Nondirectional.yml) ✔️
- [TACAN](api/Arinc424.Navigation.TacticalSystem.yml) 🚧

# [Airspace](#tab/airspace)
- [Controlled Airspace](api/Arinc424.Airspace.ControlledAirspace.yml) ✔️
- [FIR/UIR](api/Arinc424.Airspace.FlightInfoRegion.yml) ✔️
- [Restrictive Airspace](api/Arinc424.Airspace.RestrictiveAirspace.yml) ✔️

# [Company Routes](#tab/company)
- [Company Routes](api/Arinc424.Routing.CompanyRoute.yml) 🚧
- [Alternate Records](api/Arinc424.Routing.Alternate.yml) 🚧
- [Helicopter operation Routes](api/Arinc424.Routing.HelicopterCompanyRoute.yml) 🚧

# [Tables](#tab/tables)
- [Cruising Tables](api/Arinc424.Tables.CruiseTable.yml) ✔️
- [Geographical Reference](api/Arinc424.Tables.GeographicalReference.yml) 🚧
- [Communication Type](api/Arinc424.Tables.CommunicationType.yml) 🚧
---
