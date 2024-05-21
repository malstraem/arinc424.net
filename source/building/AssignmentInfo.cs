using System.Reflection;
using System.Text.RegularExpressions;

namespace Arinc424.Building;

internal abstract class AssignmentInfo(PropertyInfo property, Regex? regex)
{
    internal Regex? Regex { get; } = regex;

    internal PropertyInfo Property { get; } = property;
}
