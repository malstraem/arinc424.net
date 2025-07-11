using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace Arinc424.Linking;

using Diagnostics;

internal abstract class Link<TRecord>(PropertyInfo property) where TRecord : Record424
{
    protected readonly PropertyInfo property = property;

    internal abstract bool TryLink(TRecord record, Unique unique, [NotNullWhen(false)] out Diagnostic? diagnostic);
}
