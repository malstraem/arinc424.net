using System.Reflection;

namespace Arinc424.Attributes;

using Linking;

/**<summary>
Specifies <c>Airport/Heliport</c> identifier range.
</summary>*/
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Property, AllowMultiple = true)]
internal class PortAttribute(int left, int right) : LinkAttribute(left, right)
{
    internal override Link<TRecord> GetLink<TRecord>
    (
        PropertyInfo property,
        Supplement supplement,
        IcaoAttribute? icao,
        PortAttribute? port
    )
    {
        /* will never be thrown if the integrity tests pass */
        icao = property.GetCustomAttributes<IcaoAttribute>().BySupplement(supplement) ?? icao
            ?? throw new Exception($"No '{nameof(IcaoAttribute)}' was found for {typeof(TRecord).Name}.{property.Name} property.");

        var info = GetInfo(property.GetCustomAttributes<IcaoAttribute>().BySupplement(supplement) ?? icao!, null);

        var portType = typeof(Ground.Port);

        var primary = portType.GetCustomAttribute<IdAttribute>()?.GetInfo
        (
            portType.GetCustomAttributes<IcaoAttribute>().BySupplement(supplement),
            portType.GetCustomAttributes<PortAttribute>().BySupplement(supplement)
        );

        var type = typeof(Port<>).MakeGenericType(typeof(TRecord));

        return (Link<TRecord>)Activator.CreateInstance(type, property, primary, info)!;
    }
}
