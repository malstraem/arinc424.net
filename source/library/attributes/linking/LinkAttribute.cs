using System.Reflection;

namespace Arinc424.Attributes;

using Linking;

/// <inheritdoc/>
internal abstract class LinkAttribute(int left, int right) : IdAttribute(left, right)
{
    internal abstract Link<TRecord> GetLink<TRecord>
    (
        PropertyInfo property,
        Supplement supplement,
        IcaoAttribute? icao,
        PortAttribute? port
    ) where TRecord : Record424;
}
