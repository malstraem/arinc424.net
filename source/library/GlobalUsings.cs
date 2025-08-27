global using System.ComponentModel;
global using System.Diagnostics;

global using Arinc424.Attributes;
global using Arinc424.Converters;

global using Builds = System.Collections.Generic.Dictionary<System.Type, System.Collections.Generic.Queue<Arinc424.Build>>;
global using Invalid = System.Collections.Frozen.FrozenDictionary<Arinc424.Record424, Arinc424.Diagnostic[]>;
