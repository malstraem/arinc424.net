using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace Arinc424.Linking;

internal abstract class Link(PropertyInfo property, KeyInfo info, bool isPolymorph)
{
    protected readonly KeyInfo info = info;

    protected readonly PropertyInfo property = property;

    protected readonly NullabilityState nullState = new NullabilityInfoContext().Create(property).ReadState;

    internal Type Type => property.PropertyType;

    internal bool IsPolymorph { get; } = isPolymorph;
}

internal abstract class Link<R>(PropertyInfo property, KeyInfo info, bool isPolymorph = false)
    : Link(property, info, isPolymorph)
        where R : Record424
{
    internal abstract bool TryLink(
        R record,
        Unique unique,
        Meta424 meta,
        [NotNullWhen(false)] out Diagnostic? diagnostic
    );
}
