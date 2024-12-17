using System.Reflection;
using System.Text.RegularExpressions;

using Arinc424.Diagnostics;

namespace Arinc424.Building;

/// <summary>
/// Assignment operation to set <see cref="Record424"/> property.
/// </summary>
internal abstract class Assignment<TRecord>(PropertyInfo property) where TRecord : Record424
{
    protected PropertyInfo property = property;

    internal Regex? Regex { get; } = property.GetCustomAttribute<ValidationAttribute>()?.Regex;

    internal NullabilityInfo? NullabilityInfo { get; } = property.PropertyType.IsClass ? new NullabilityInfoContext().Create(property) : null;

    internal abstract void Assign(TRecord record, ReadOnlySpan<char> @string, Queue<Diagnostic> diagnostics);
}
