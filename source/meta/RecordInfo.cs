using System.Reflection;

using Arinc.Spec424.Attributes;

namespace Arinc.Spec424;

internal record RecordInfo
{
    private readonly int sectionIndex;

    private readonly int subsectionIndex;

    private readonly char sectionChar;

    private readonly char subsectionChar;

    private readonly int? continuationNumberIndex;

    internal RecordInfo(MemberInfo recordType, RecordAttribute recordAttribute)
    {
        sectionIndex = recordAttribute.SectionIndex;
        sectionChar = recordAttribute.SectionChar;
        subsectionIndex = recordAttribute.SubsectionIndex;
        subsectionChar = recordAttribute.SubsectionChar;
        continuationNumberIndex = recordType.GetCustomAttribute<ContinuationAttribute>()?.Index;
    }

    internal bool IsMatch(string @string) => @string[0] is 'S'
                                          && @string[sectionIndex] == sectionChar
                                          && @string[subsectionIndex] == subsectionChar
                                          && (continuationNumberIndex is null || @string[continuationNumberIndex.Value] is '0' or '1');
}
