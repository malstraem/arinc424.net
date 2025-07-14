using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace Arinc424.Linking;

using Diagnostics;

internal sealed class Port<TRecord>(PropertyInfo property, in KeyInfo primary, in KeyInfo info)
    : Known<TRecord, Foreign, Ground.Port>(property, in info)
    where TRecord : Record424
{
    private readonly KeyInfo primary = primary;

    internal override bool TryLink(TRecord record, Unique unique, [NotNullWhen(false)] out Diagnostic? diagnostic)
    {
        diagnostic = null;

        if (!Foreign.TryGetKey(record.Source, in info, in primary, out string? key))
            return true;

        if (unique.TryGetPort(key, out var port))
        {
            set(record, (Ground.Port)port); /* guarantee by design */
            return true;
        }
        diagnostic = new InvalidLink(record, property, in info, LinkError.NoOneFound);
        return false;
    }
}
