using System.Reflection;
using System.Text.RegularExpressions;

using Arinc.Spec424.Attributes;

namespace Arinc.Spec424.Building;

internal record AssignmentInfo
{
    internal Regex? Regex { get; init; }

    internal required PropertyInfo Property { get; init; }
}

internal record IndexAssignmentInfo : AssignmentInfo
{
    internal required int Index { get; init; }

    internal TransformAttribute? Transform { get; init; }
}

internal record RangeAssignmentInfo : AssignmentInfo
{
    internal required Range Range { get; init; }

    internal DecodeAttribute? Decode { get; init; }
}
