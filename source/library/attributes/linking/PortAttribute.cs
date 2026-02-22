using System.Reflection;

namespace Arinc424.Attributes;

using Linking;

/**<summary>
Specifies <c>Airport/Heliport</c> identifier range.
</summary>
<inheritdoc/>*/
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Property, AllowMultiple = true)]
internal class PortAttribute(int left, int right) : LinkAttribute(left, right)
{
    internal override Link<R> GetLink<R>(
        PropertyInfo property,
        Supplement supplement,
        IcaoAttribute? icao,
        PortAttribute? port)
    {
        /* will never be thrown if the integrity tests pass */
        icao = property.GetCustomAttributes<IcaoAttribute>().BySupplement(supplement) ?? icao
            ?? throw new Exception($"No '{nameof(IcaoAttribute)}' was found for {typeof(R).Name}.{property.Name} property.");

        var info = GetInfo(property.GetCustomAttributes<IcaoAttribute>().BySupplement(supplement) ?? icao!, null);

        var type = typeof(Known<,>).MakeGenericType(typeof(R), property.PropertyType);

        return (Link<R>)Activator.CreateInstance(type, property, info)!;
    }
}
