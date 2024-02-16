using System.Reflection;

using Arinc.Spec424.Attributes;

namespace Arinc.Spec424;

internal record RecordInfo
{
    private readonly int sectionIndex;

    private readonly int subsectionIndex;

    private readonly char sectionChar;

    private readonly char subsectionChar;

    internal readonly int? continuationIndex;

    internal RecordInfo(MemberInfo recordType, RecordAttribute recordAttribute)
    {
        sectionIndex = recordAttribute.SectionIndex;
        sectionChar = recordAttribute.SectionChar;
        subsectionIndex = recordAttribute.SubsectionIndex;
        subsectionChar = recordAttribute.SubsectionChar;
        continuationIndex = recordType.GetCustomAttribute<ContinuationAttribute>()?.Index;
    }

    internal bool IsMatch(string @string) => @string[sectionIndex] == sectionChar && @string[subsectionIndex] == subsectionChar;
}
