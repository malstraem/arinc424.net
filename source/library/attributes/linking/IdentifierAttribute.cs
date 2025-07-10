using System.Reflection;

namespace Arinc424.Attributes;

using Linking;

/// <summary>Specifies <see cref="IIdentity.Identifier"/> range for linking.</summary>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Property, AllowMultiple = true)]
internal class IdentifierAttribute(int left, int right) : RangeAttribute(left, right)
{
    internal Link<TRecord> GetLink<TRecord>(PropertyInfo property, IcaoAttribute? icao, PortAttribute? port, Supplement supplement)
        where TRecord : Record424
    {
        LinkInfo info = new()
        {
            Port = port?.Range,
            Icao = property.GetCustomAttributes<IcaoAttribute>().BySupplement(supplement)?.Range ?? icao?.Range,
            Identifier = Range
        };

        var typeAttribute = property.GetCustomAttributes<TypeAttribute>().BySupplement(supplement);

        return typeAttribute is not null
            ? (Link<TRecord>)Activator
                .CreateInstance(typeof(Polymorph<,>)
                    .MakeGenericType(typeof(TRecord), property.PropertyType), info, property, typeAttribute)!

            : (Link<TRecord>)Activator
                .CreateInstance(typeof(Known<,>)
                    .MakeGenericType(typeof(TRecord), property.PropertyType), info, property)!;
    }
}
