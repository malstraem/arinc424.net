using System.Reflection;

namespace Arinc424.Attributes;

using Linking;

/// <inheritdoc/>
internal abstract class LinkAttribute(int left, int right) : IdAttribute(left, right)
{
    internal abstract Link<R> GetLink<R>(
        PropertyInfo property,
        Supplement supplement,
        IcaoAttribute? icao,
        PortAttribute? port
    ) where R : Record424;
}
