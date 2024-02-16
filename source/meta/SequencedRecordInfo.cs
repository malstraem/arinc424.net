using Arinc.Spec424.Attributes;

namespace Arinc.Spec424;

internal record SequencedRecordInfo : RecordInfo
{
    internal SequencedRecordInfo(Type type, RecordAttribute recordAttribute, SequencedAttribute sequencedAttribute) : base(type, recordAttribute)
        => SequenceRange = sequencedAttribute.Range;

    internal Range SequenceRange { get; }
}
