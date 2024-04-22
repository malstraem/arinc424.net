using System.Diagnostics;
using System.Reflection;
using System.Text.RegularExpressions;

using Arinc424.Attributes;

namespace Arinc424.Building;

[DebuggerDisplay($"{{{nameof(Property)}}}")]
internal class AssignmentInfo
{
    internal Regex? Regex { get; set; }

    internal required PropertyInfo Property { get; set; }
}

internal class IndexAssignmentInfo : AssignmentInfo
{
    internal required int Index { get; set; }

    internal TransformAttribute? Transform { get; set; }
}

internal class RangeAssignmentInfo : AssignmentInfo
{
    internal required Range Range { get; set; }

    internal DecodeAttribute? Decode { get; set; }
}
