using Arinc424.Airspace;
using Arinc424.Building;

namespace Arinc424.Processing;

internal abstract class SpaceConcateTrigger
{
    internal static bool Trigger(Volume current, Volume next)
        => char.IsWhiteSpace(current.MultipleCode) || char.IsWhiteSpace(next.MultipleCode) || next.MultipleCode <= current.MultipleCode;
}

internal abstract class ControlledSpaceConcatenater : IProcessor<ControlledSpace, ControlledVolume>
{
    private static ControlledSpace New(ControlledVolume sub) => new() { IcaoCode = sub.IcaoCode, Name = sub.Name };

    public static new IEnumerable<Build<ControlledSpace>> Process(Queue<Build<ControlledVolume>> records)
        => Concatenater<ControlledSpace, ControlledVolume>.Concat(records, New, SpaceConcateTrigger.Trigger);
}

internal abstract class RestrictiveSpaceConcatenater : IProcessor<RestrictiveSpace, RestrictiveVolume>
{
    private static RestrictiveSpace New(RestrictiveVolume sub) => new() { IcaoCode = sub.IcaoCode, Name = sub.Name, Designation = sub.Designation };

    public static new IEnumerable<Build<RestrictiveSpace>> Process(Queue<Build<RestrictiveVolume>> records)
        => Concatenater<RestrictiveSpace, RestrictiveVolume>.Concat(records, New, SpaceConcateTrigger.Trigger);
}
