> [!NOTE]
> *work in progress and target on ver. 23 of the specification (with backward compatibility to 18)*  
*any reviews and PRs are welcome, nuget package will be released once the API is stabilized*

> [!WARNING]
*if you see any issues testing the library on real world data, please report it*

# Overview

This is a long-term research and proof of concept to provide a model and reader for the globally used **`ARINC 424`** aircraft navigation data using metaprogramming.

While the **`ARINC 424`** specification describes entities (*or records in terms*) with 132-byte fixed-length strings, this library creates
a database object model via building entities using reflection and runtime compilation.

Most terms are converted according to the specification into associated enumerations or numeric values ​​on the fly.

In addition, relationships between entities are established after the building stage.

In practice, this allows you to explore and manipulate the tree-like representation of **`ARINC 424`** database.

See [docs](https://malstraem.github.io/arinc424.net) to know how specification is mapped.

## Getting started

First, you need to create runtime compiled metadata. This describes how strings will be parsed 
and entities created based on [supplement](https://malstraem.github.io/arinc424.net/api/Arinc424.Supplement.html).

```csharp
var meta = Meta424.Create(Supplement.V20);
```

And you can try to get navigation [data](https://malstraem.github.io/arinc424.net/api/Arinc424.Data424.html) from the strings 
leaving [builds](https://malstraem.github.io/arinc424.net/api/Arinc424.Building.Build.html) with diagnostics 
(bad coded fields, missing links, etc) and skipped strings that don't match entity types.

```csharp
var data = Data424.Create(meta, strings, out var invalid, out var skipped);
```

## Build and prerequisites

- .NET 9 SDK
- `dotnet build`

The project actively uses the Roslyn API to generate converters of specification terms to internal types. Use a suitable IDE to view the generated code.
