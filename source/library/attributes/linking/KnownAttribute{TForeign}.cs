using System.Reflection;

namespace Arinc424.Attributes;

using Linking;

/// <summary>Specifies <see cref="IIdentity.Identifier"/> range for strong typed link.</summary>
/// <inheritdoc/>
[AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
internal class KnownAttribute(int left, int right) : LinkAttribute(left, right)
{
    internal override Link<TRecord> GetLink<TRecord>
    (
        PropertyInfo property,
        Supplement supplement,
        IcaoAttribute? icao,
        PortAttribute? port
    )
    {
        var info = GetInfo(property.GetCustomAttributes<IcaoAttribute>().BySupplement(supplement) ?? icao, port);

        var type = typeof(Known<,>).MakeGenericType(typeof(TRecord), property.PropertyType);

        return (Link<TRecord>)Activator.CreateInstance(type, property, info)!;
    }
}
