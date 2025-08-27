namespace Arinc424.Building;

internal class Composition(Type[] types)
{
    internal Type[] Types { get; } = types;

    internal Type Top { get; } = types.Last();

    internal Type Low { get; } = types.First();
}
