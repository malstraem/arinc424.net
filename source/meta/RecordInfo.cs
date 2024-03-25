using System.Reflection;

using Arinc.Spec424.Attributes;

namespace Arinc.Spec424;

internal record RecordInfo
{
    private readonly int sectionIndex;

    private readonly int subsectionIndex;

    internal readonly char sectionChar;

    internal readonly char subsectionChar;

    internal readonly int? continuationIndex;

    internal RecordInfo(MemberInfo recordType, RecordAttribute recordAttribute)
    {
        sectionChar = recordAttribute.SectionChar;
        subsectionChar = recordAttribute.SubsectionChar;
        sectionIndex = recordAttribute.SectionIndex;
        subsectionIndex = recordAttribute.SubsectionIndex;
        continuationIndex = recordType.GetCustomAttribute<ContinuousAttribute>()?.Index;
    }

    internal bool IsMatch(string @string) => @string[sectionIndex] == sectionChar && @string[subsectionIndex] == subsectionChar;
}
