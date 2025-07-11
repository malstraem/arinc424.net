using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace Arinc424.Linking;

using Diagnostics;

internal sealed class Port<TRecord>(Foreign foreign, PropertyInfo property) : Known<TRecord, Foreign, Ground.Port>(foreign, property)
    where TRecord : Record424
{
    private static readonly Primary primary = Primary.Create(typeof(Ground.Port))!;

    internal override bool TryLink(TRecord record, Unique unique, [NotNullWhen(false)] out Diagnostic? diagnostic)
    {
        diagnostic = null;

        if (!foreign.TryGetKey(record.Source, primary, out string? key))
            return true;

        if (unique.TryGetPort(key, out var port))
        {
            set(record, (Ground.Port)port); /* guarantee by design */
            return true;
        }
        diagnostic = new InvalidLink(record, property, foreign.Info, LinkError.NoOneFound);
        return false;
    }
}
