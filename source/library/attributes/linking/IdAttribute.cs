using System.Reflection;

namespace Arinc424.Attributes;

using Linking;

/// <summary>Specifies <see cref="IIdentity.Identifier"/> range for strong typed link.</summary>
/// <inheritdoc/>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Property, AllowMultiple = true)]
internal class KnownAttribute<TForeign>(int left, int right) : RangeAttribute(left, right)
    where TForeign : IForeign<TForeign>
{
    internal Link<TRecord> GetLink<TRecord>(PropertyInfo property, IcaoAttribute? icao, PortAttribute? port, Supplement supplement)
        where TRecord : Record424
    {
        KeyInfo info = new()
        {
            Port = port?.Range,
            Icao = property.GetCustomAttributes<IcaoAttribute>().BySupplement(supplement)?.Range ?? icao?.Range,
            Identifier = Range
        };

        var foreign = TForeign.Create(info);

        return (Link<TRecord>)Activator
                .CreateInstance(typeof(Known<,,>)
                    .MakeGenericType(typeof(TRecord), typeof(TForeign), property.PropertyType), foreign, property)!;
    }
}

/// <summary>Specifies <see cref="IIdentity.Identifier"/> range for polymorph link.</summary>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Property, AllowMultiple = true)]
internal class PolymorphAttribute<TForeign>(int left, int right) : RangeAttribute(left, right)
    where TForeign : IPolymorphForeign<TForeign>
{
    internal Link<TRecord> GetLink<TRecord>(PropertyInfo property, IcaoAttribute? icao, PortAttribute? port, Supplement supplement)
        where TRecord : Record424
    {
        KeyInfo info = new()
        {
            Port = port?.Range,
            Icao = property.GetCustomAttributes<IcaoAttribute>().BySupplement(supplement)?.Range ?? icao?.Range,
            Identifier = Range
        };

        var typeAttribute = property.GetCustomAttributes<TypeAttribute>().BySupplement(supplement)
            ?? throw new Exception("No type attribute found");

        return (Link<TRecord>)Activator
                .CreateInstance(typeof(Polymorph<,,>)
                    .MakeGenericType(typeof(TRecord), typeof(TForeign), property.PropertyType), TForeign.Create(info), property, typeAttribute)!;
    }
}

/// <inheritdoc cref="KnownAttribute{TForeign}"/>
internal class KnownAttribute(int left, int right) : KnownAttribute<Foreign>(left, right);

/// <inheritdoc cref="KnownAttribute{TForeign}"/>
internal class KnownAttribute(int left, int right) : KnownAttribute<Foreign>(left, right);
