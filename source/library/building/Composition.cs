namespace Arinc424.Building;

using Processing;
using Linking;

internal class Composition(Type[] types)
{
    internal Type Top { get; } = types.Last();

    internal Type Low { get; } = types.First();

    /// <summary>Pipelines for bare and composition types including top level.</summary>
    internal required IPipeline[] Pipelines { get; init; }

    /// <summary>Relationships for bare and composition types including top level.</summary>
    internal required Relationships[] Relations { get; init; }
}
