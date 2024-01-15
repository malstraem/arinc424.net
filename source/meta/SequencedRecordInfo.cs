using Arinc.Spec424.Attributes;

namespace Arinc.Spec424;

internal record SequencedRecordInfo(Type type, RecordAttribute recordAttribute, SequencedAttribute sequencedAttribute) : RecordInfo(type, recordAttribute)
{
    internal Range SequenceNumberRange { get; } = sequencedAttribute.Range;
}
