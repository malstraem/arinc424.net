using System.Reflection;
using System.Text.RegularExpressions;

using Arinc424.Diagnostics;

namespace Arinc424.Building;

/// <summary>
/// Assignment operation to set <see cref="Record424"/> property.
/// </summary>
internal abstract class Assignment<TRecord>(PropertyInfo property) where TRecord : Record424
{
    internal Regex? Regex { get; } = property.GetCustomAttribute<ValidationAttribute>()?.Regex;

    internal PropertyInfo Property { get; } = property;

    internal NullabilityInfo NullabilityInfo { get; } = new NullabilityInfoContext().Create(property);

    internal abstract void Assign(TRecord record, ReadOnlySpan<char> @string, Queue<Diagnostic> diagnostics);
}
