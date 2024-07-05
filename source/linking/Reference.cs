namespace Arinc424.Linking;

internal class Reference(string key, Type type)
{
    internal string Key { get; } = key;

    internal Type Type { get; } = type;
}
