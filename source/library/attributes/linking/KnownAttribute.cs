using System.Reflection;

namespace Arinc424.Attributes;

using Linking;

/**<summary>
Specifies <see cref="IIdentity.Identifier"/> range for strong typed relation.
</summary>
<inheritdoc/>*/
[AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
internal sealed class KnownAttribute(int left, int right) : LinkAttribute(left, right)
{
    internal override Link<R> GetLink<R>(
        PropertyInfo property,
        Supplement supplement,
        IcaoAttribute? icao,
        PortAttribute? port)
    {
        var info = GetInfo(property.GetCustomAttributes<IcaoAttribute>().BySupplement(supplement) ?? icao, port);

        var type = typeof(Known<,>).MakeGenericType(typeof(R), property.PropertyType);

        return (Link<R>)Activator.CreateInstance(type, property, info)!;
    }
}
