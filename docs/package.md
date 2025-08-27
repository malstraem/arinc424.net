# Overview

While the **`ARINC 424`** specification describes entities with 132-byte fixed-length strings, this library creates
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

So you can get navigation [data](https://malstraem.github.io/arinc424.net/api/Arinc424.Data424.html) from the strings with
remaining [diagnostics](https://malstraem.github.io/arinc424.net/api/Arinc424.Diagnostic.html) (bad coded fields, miss links, etc)
and skipped strings that don't match entity types.

```csharp
var data = Data424.Create(meta, strings, out var skipped, out var invalid);
```
