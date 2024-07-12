using System.Reflection;

namespace Arinc424.Building;

internal static class TypeExtensions
{
    internal static IEnumerable<T> GetAttributes<T>(this Type type, Supplement supplement) where T : SupplementAttribute
    {
        var attributes = type.GetCustomAttributes<T>();

        foreach (var attribute in attributes)
        {
            if (supplement is Supplement.None)
                yield return attribute;

            if (attribute.Supplement <= supplement)
                yield return attribute;
        }
    }
}
