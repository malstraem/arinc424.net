*work in progress and target on ver. 20 of the specification (with potential up to 23 with backward compatibility)*

*any reviews and PRs are welcome*

*nuget package will be deployed once the API is stabilized*

# Overview

While the **`ARINC 424`** specification describes entities (*or records*) with 132-byte fixed-length string, this library creates
a database object model via building entities using reflection and runtime compilation.

Most terms are converted according to the specification into associated enumerations or numeric values ​​on the fly.

In addition, relationships between entities are established after the building stage.

In practice, this allows you to explore and manipulate the tree-like representation of **`ARINC 424`** database.

See [docs](https://malstraem.github.io/arinc424.net) to know how specification is mapped.

## Build and prerequisites

- .NET 8
- `dotnet build`

Project is actively used Roslyn API to generate converters for specification terms to internal types.
Use a suitable IDE to view the generated code.
