using System.Reflection;

using Arinc424.Linking;

namespace Arinc424.Attributes;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Property, AllowMultiple = true)]
internal class IdentifierAttribute(int left, int right, Supplement start = Supplement.V18) : RangeAttribute(left, right, start)
{
    internal virtual Link<TRecord> GetLink<TRecord>(PropertyInfo property, Supplement supplement) where TRecord : Record424
    {
        var type = typeof(TRecord);

        var port = type.GetCustomAttributes<PortAttribute>().BySupplement(supplement)?.Range;
        var icao = type.GetCustomAttributes<IcaoAttribute>().BySupplement(supplement)?.Range;

        KeyInfo ranges = new()
        {
            Port = port,
            Icao = property.GetCustomAttributes<IcaoAttribute>().BySupplement(supplement)?.Range ?? icao,
            Identifier = Range
        };

        var possible = property.GetCustomAttribute<PossibleAttribute>();

        if (possible is not null)
        {
            return (Link<TRecord>)Activator
                .CreateInstance(typeof(PossibleLink<,>)
                    .MakeGenericType(typeof(TRecord), property.PropertyType), ranges, property, possible.Types)!;
        }

        var typeAttribute = property.GetCustomAttributes<TypeAttribute>().BySupplement(supplement);

        return typeAttribute is not null
            ? (Link<TRecord>)Activator
                .CreateInstance(typeof(PolymorphLink<,>)
                    .MakeGenericType(typeof(TRecord), property.PropertyType), ranges, property, typeAttribute)!

            : (Link<TRecord>)Activator
                .CreateInstance(typeof(Link<,>)
                    .MakeGenericType(typeof(TRecord), property.PropertyType), ranges, property)!;
    }
}
