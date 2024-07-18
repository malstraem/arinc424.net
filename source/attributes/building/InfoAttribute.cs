using System.Reflection;

using Arinc424.Building;

namespace Arinc424.Attributes;

[AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
internal abstract class InfoAttribute : Attribute
{
    internal abstract IEnumerable<RecordInfo> GetInfo(Supplement supplement);
}

internal class RecordAttribute<TRecord> : InfoAttribute where TRecord : Record424, new()
{
    internal override IEnumerable<RecordInfo> GetInfo(Supplement supplement) => new RecordInfo<TRecord>(supplement).DuplicateBySection();
}

internal sealed class SequenceAttribute<TSequence, TSub> : RecordAttribute<TSequence>
    where TSequence : Record424<TSub>, new()
    where TSub : Record424, new()
{
    internal override IEnumerable<RecordInfo> GetInfo(Supplement supplement)
    {
        var range = typeof(TSequence).GetCustomAttributes<SequencedAttribute>().BySupplement(supplement)?.Range;

        return (range is null ? new RecordInfo<TSequence>(supplement) : new RecordInfo<TSequence, TSub>(supplement, range.Value)).DuplicateBySection();
    }
}
