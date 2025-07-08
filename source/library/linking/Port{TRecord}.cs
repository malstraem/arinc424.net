using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace Arinc424.Linking;

using Diagnostics;

internal sealed class Port<TRecord>(LinkInfo info, PropertyInfo property) : Known<TRecord, Ground.Port>(info, property)
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
            //unique.meta.TypeInfo[type].Relations!.Process(referenced, record);
            return true;
        }
        diagnostic = new InvalidLink(record, property, foreign.Info, LinkError.NoOneFound);
        return false;
    }
}
