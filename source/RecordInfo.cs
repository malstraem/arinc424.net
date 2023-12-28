using System.Reflection;

using Arinc.Spec424.Attributes;

namespace Arinc.Spec424;

internal record RecordInfo(Type recordType, RecordAttribute recordAttribute)
{
    internal int SectionIndex { get; } = recordAttribute.Index;

    internal int SubsectionIndex { get; } = recordAttribute.SubsectionIndex;

    internal char SectionChar { get; } = recordAttribute.Char;

    internal char SubsectionChar { get; } = recordAttribute.SubsectionChar;

    internal int? ContinuationNumberIndex { get; } = recordType.GetCustomAttribute<ContinuationAttribute>()?.Index;

    internal bool IsMatch(string @string) => @string[0] is 'S'
                                          && @string[SectionIndex] == SectionChar
                                          && @string[SubsectionIndex] == SubsectionChar
                                          && (ContinuationNumberIndex is null || @string[ContinuationNumberIndex.Value] is '0' or '1');
}
