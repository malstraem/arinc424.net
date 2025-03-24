using System.Collections.Frozen;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace Arinc424.Building;

internal class Continuations
{
    private int continuationIndex;
#pragma warning disable CS8618
    private Dictionary<ContinuationAttribute, Queue<string>> continuations;

    private FrozenDictionary<ContinuationAttribute, RecordInfo> info;

    private FrozenDictionary<ContinuationAttribute, PropertyInfo> properties;
#pragma warning restore CS8618
    internal static Continuations? Create(Composition composition, Supplement supplement)
    {
        var continuous = composition.Top.GetCustomAttributes<ContinuousAttribute>().BySupplement(supplement);

        if (continuous is null)
            return null;

        Dictionary<ContinuationAttribute, RecordInfo> info = [];
        Dictionary<ContinuationAttribute, PropertyInfo> properties = [];

        Dictionary<ContinuationAttribute, Queue<string>> continuations = [];

        foreach (var property in composition.Low.GetProperties())
        {
            if (property.GetCustomAttribute<ContinueAttribute>() is null)
                continue;

            var continuation = property.PropertyType.GetElementType()!.GetCustomAttribute<ContinuationAttribute>()!;

            info[continuation] = RecordInfo.Create((properties[continuation] = property).PropertyType.GetElementType()!, supplement);

            continuations[continuation] = [];
        }
        return new Continuations()
        {
            info = info.ToFrozenDictionary(),
            properties = properties.ToFrozenDictionary(),
            continuations = continuations,
            continuationIndex = continuous.Index
        };
    }

    private bool TryMatch(string @string, [NotNullWhen(true)] out ContinuationAttribute? continuation)
    {
        foreach (var (attribute, _) in info)
        {
            if (attribute.IsMatch(@string))
            {
                continuation = attribute;
                return true;
            }
        }
        continuation = null;
        return false;
    }

    internal bool TryProcess(string @string)
    {
        if (@string[continuationIndex] <= '1')
            return false;

        if (TryMatch(@string, out var continuation))
            continuations[continuation].Enqueue(@string);

        return true;
    }

    internal void Set(Record424 record)
    {
        foreach (var (continuation, @strings) in continuations)
        {
            var builds = info[continuation].Build(strings);

            if (builds.Count == 0)
                continue;

            var property = properties[continuation];

            var array = Array.CreateInstance(property.PropertyType.GetElementType()!, builds.Count);

            int i = 0;
            foreach (var build in builds)
                array.SetValue(build.Record, i++);

            property.SetValue(record, array);
        }
    }
}
