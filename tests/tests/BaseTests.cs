using System.Collections.Frozen;

namespace Arinc424.Tests;

public abstract class BaseTests
{
    protected readonly FrozenDictionary<Supplement, Meta424> meta;

    public BaseTests()
    {
        Dictionary<Supplement, Meta424> meta = [];

        foreach (var supplement in Enum.GetValues<Supplement>())
            meta[supplement] = Meta424.Create(supplement);

        this.meta = meta.ToFrozenDictionary();
    }
}
