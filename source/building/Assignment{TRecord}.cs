using System.Reflection;
using System.Text.RegularExpressions;

using Arinc424.Diagnostics;

namespace Arinc424.Building;

internal abstract class Assignment<TRecord>(PropertyInfo property) where TRecord : Record424
{
    [Obsolete("maybe need to take out for potential validation logic")]
    internal Regex? Regex { get; } = property.GetCustomAttribute<ValidationAttribute>()?.Regex;

    internal PropertyInfo Property { get; } = property;

    internal NullabilityInfo NullabilityInfo { get; } = new NullabilityInfoContext().Create(property);

    internal abstract void Assign(TRecord record, ReadOnlySpan<char> @string, Queue<Diagnostic> diagnostics);
}
