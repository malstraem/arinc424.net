using System.Reflection;

namespace Arinc424.Attributes;

using Linking;

/**<summary>
Specifies <see cref="IIdentity.Identifier"/> range for polymorph relation.
</summary>
<inheritdoc/>*/
[AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
internal class PolymorphAttribute(int left, int right) : LinkAttribute(left, right)
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
        var typeAttribute = property.GetCustomAttributes<TypeAttribute>().BySupplement(supplement)
            ?? throw new Exception($"No '{nameof(TypeAttribute)}' was found for {typeof(TRecord).Name}.{property.Name} property.");

        var info = GetInfo(property.GetCustomAttributes<IcaoAttribute>().BySupplement(supplement) ?? icao, port);

        var type = typeof(Polymorph<,>).MakeGenericType(typeof(TRecord), property.PropertyType);

        return (Link<TRecord>)Activator.CreateInstance(type, property, typeAttribute, info)!;
    }
}
