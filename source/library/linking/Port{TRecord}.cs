using System.Runtime.CompilerServices;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace Arinc424.Linking;

using Diagnostics;

internal sealed class Port<TRecord>(PropertyInfo property, in KeyInfo info)
    : Known<TRecord, Ground.Port>(property, in info)
        where TRecord : Record424
{
    internal override bool TryLink(TRecord record, Unique unique, [NotNullWhen(false)] out Diagnostic? diagnostic)
    {
        if (!info.TryGetKey(record.Source, out string? key))
        {
            if (nullState == NullabilityState.NotNull)
            {
                diagnostic = BadLink(LinkError.Null, record, property.PropertyType);
                return false;
            }
            diagnostic = null;
            return true;
        }
        if (unique.TryGetPort(key!, out var port))
        {
            diagnostic = null;
            set(record, Unsafe.As<Ground.Port>(port)); /* guarantee by design */
            return true;
        }
        diagnostic = BadLink(LinkError.KeyNotFound, record);
        return false;
    }
}
