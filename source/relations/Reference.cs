using System.Reflection;

namespace Arinc424.Relations;

internal class Reference(string key, Type type, PropertyInfo property)
{
    internal string Key = key;

    internal Type Type = type;

    internal PropertyInfo Property = property;
}
