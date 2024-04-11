*work in progress and target on ver. 20 of the specification*

*any reviews and PRs are welcome*

# Overview

While the **`ARINC 424`** specification describes entities (*or records*) with 132-byte fixed-length string, this library creates 
a database object model at load time via building entities using reflection. Most terms are converted according 
to the specification into associated enums or numeric values on the fly.

In addition, relationships between entities are established after the building stage.

In practice, this allows you to explore and manipulate the tree-like representation of **`ARINC 424`** database.

# State and plans

After the finalization of the primary records, the error handle and log during parsing will be introduced to guarantee 
that as many objects and relationships as possible will be created from the strings.

The NuGet package will be deployed once the API is stabilized.

- Grid MORA 🚧
- Navaid
  - VHF Navaid ✔️
  - NDB Navaid ✔️
  - TACAN 🚧
- Enroute
  - Waypoints ✔️
  - Airway Markers 🚧
  - Holding Patterns ✔️
  - Airways and Routes ✔️
  - Special Activity Areas 🚧
  - Preferred Routes 🚧
  - Airway Restrictions 🚧
  - Communications 
- Heliport
  - Pads 🚧
  - Terminal Waypoints 🚧
  - SID/STAR/Approach Procedures 🚧
  - TAA 🚧
  - MSA 🚧
  - SBAS Path Point 🚧
  - Communications 🚧
- Airport
  - Reference Points ✔️
  - Gates 🚧
  - Terminal Waypoints ✔️
  - SID/STAR/Approach Procedures ✔️
  - Runways ✔️
  - Localizer/Glide Slope 🚧
  - TAA 🚧
  - MLS 🚧
  - Localizer Marker 🚧
  - Terminal NDB ✔️
  - SBAS Path Point 🚧
  - GBAS Path Point 🚧
  - Flight Planning 🚧
  - MSA 🚧
  - GLS Station 🚧
  - Communications 🚧
- Company Routes
  - Company Routes 🚧
  - Alternate Records 🚧
  - Helicopter operation Routes 🚧
- Tables
  - Cruising Tables 🚧
  - Geographical Reference 🚧
  - Communication Type 🚧
- Airspace
  - Controlled Airspace ✔️
  - FIR/UIR ✔️
  - Restrictive Airspace ✔️
