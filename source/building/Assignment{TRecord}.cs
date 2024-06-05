using System.Reflection;
using System.Text.RegularExpressions;

using Arinc424.Diagnostics;

namespace Arinc424.Building;

internal abstract class Assignment<TRecord>(PropertyInfo property, Regex? regex) where TRecord : Record424
{
    private static readonly NullabilityInfoContext nullabilityContext = new();

    [Obsolete("maybe need to take out for potential validation logic")]
    internal Regex? Regex { get; } = regex;

    internal PropertyInfo Property { get; } = property;

    internal NullabilityInfo NullabilityInfo { get; } = nullabilityContext.Create(property);

    internal abstract void Assign(TRecord record, ReadOnlySpan<char> @string, Queue<Diagnostic> diagnostics);
}
