using System.Reflection;

namespace Arinc424.Linking;

internal class Reference(string key, Type type, PropertyInfo property)
{
    internal string Key { get; } = key;

    internal Type Type { get; } = type;

    internal PropertyInfo Property { get; } = property;
}
