using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace Arinc424.Linking;

using Diagnostics;

internal abstract class Link<TRecord>(PropertyInfo property, in KeyInfo info) where TRecord : Record424
{
    protected readonly KeyInfo info = info;

    protected readonly PropertyInfo property = property;

    protected readonly NullabilityState nullState = new NullabilityInfoContext().Create(property).ReadState;

    protected BadLink BadLink(LinkError error, TRecord record, Type? type = null, string? key = null) => new()
    {
        Info = info,
        Property = property,
        Key = key,
        Type = type,
        Error = error,
        Record = record
    };

    internal abstract bool TryLink(TRecord record, Unique unique, [NotNullWhen(false)] out Diagnostic? diagnostic);
}
