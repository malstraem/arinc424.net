*work in progress and oriented on 20 version of the specification*

# Overview

While the `ARINC424` format describes entities (*or records*) with 132-byte fixed-length string, this library creates a database object model at load time via building entities with reflection. Most terms are converted according to the specification into associated enums or numeric values on the fly.

In addition, relationships between entities are determined after the building stage.

```mermaid
flowchart TB
Airport(Airport) -.-> Runways(Runways)
Airport -.-> Approaches(Approaches)
Airport -.-> Departures(StandardInstrumentDepartures)
```

In practice this allows you explore and manipulate the tree-like representation of `ARINC424` database.
