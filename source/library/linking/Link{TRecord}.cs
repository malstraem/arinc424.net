using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace Arinc424.Linking;

using Diagnostics;

internal abstract class Link(PropertyInfo property, in KeyInfo info, bool isPolymorph)
{
    protected readonly KeyInfo info = info;

    protected readonly PropertyInfo property = property;

    protected readonly NullabilityState nullState = new NullabilityInfoContext().Create(property).ReadState;

    internal Type Type => property.PropertyType;

    internal bool IsPolymorph { get; } = isPolymorph;
}

internal abstract class Link<TRecord>(PropertyInfo property, in KeyInfo info, bool isPolymorph = false)
    : Link(property, in info, isPolymorph)
    where TRecord : Record424
{
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
