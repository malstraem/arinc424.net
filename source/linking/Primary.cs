using System.Reflection;

namespace Arinc424.Linking;

internal abstract class Primary(Range identifier, Range? icao, Range? port, bool isPortOptional)
{
    protected readonly Range identifier = identifier;

    protected readonly Range? icao = icao, port = port;

    protected readonly bool isPortOptional = isPortOptional;

    internal abstract string GetKey(ReadOnlySpan<char> @string);

    internal Range? Icao => icao;

    internal Range? Port => port;

    internal Range Identifier => identifier;

    internal bool IsPortOptional => isPortOptional;
}

internal class Primary<TRecord>(Range identifier, Range? icao, Range? port, bool isPortOptional)
    : Primary(identifier, icao, port, isPortOptional) where TRecord : Record424
{
    internal static Primary<TRecord>? Create()
    {
        Range identifier;
        Range? icao, port = null;

        bool isPortOptional = false;

        var type = typeof(TRecord);

        var property = type.GetProperty(nameof(IIdentity.Identifier));

        if (property is null)
            return null;

        identifier = property.GetCustomAttribute<FieldAttribute>()!.Range;

        icao = type.GetProperty(nameof(IIcao.IcaoCode))?.GetCustomAttribute<FieldAttribute>()!.Range;

        var portProperty = type.GetProperty("Airport") ?? type.GetProperty("Heliport");

        if (portProperty is not null)
        {
            port = portProperty.GetCustomAttribute<IdentifierAttribute>()!.Range;

            var context = new NullabilityInfoContext();

            var info = context.Create(portProperty);

            if (info.ReadState is NullabilityState.Nullable)
                isPortOptional = true;
        }

        return new Primary<TRecord>(identifier, icao, port, isPortOptional);
    }

    internal override string GetKey(ReadOnlySpan<char> @string)
    {
        string key = @string[identifier].Trim().ToString();

        if (icao.HasValue)
            key += @string[icao.Value].ToString();

        if (port.HasValue)
            key += @string[port.Value].Trim().ToString();

        return key;
    }
}
