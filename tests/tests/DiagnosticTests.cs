using System.Collections.Frozen;

namespace Arinc424.Tests;

public abstract class DiagnosticTests
{
    private readonly FrozenDictionary<Supplement, Meta424> meta;

    protected T GetDiagnostic<T>(string file, Supplement supplement)
        where T : Diagnostic
    {
        string[] strings = File.ReadAllLines($"{Diagnostics}{file}");

        _ = Data424.Create(meta[supplement], strings, out string[] _, out var invalid);

        var (_, diagnostic) = invalid.First();

        return (T)diagnostic.First();
    }

    public DiagnosticTests()
    {
        Dictionary<Supplement, Meta424> meta = [];

        foreach (var supplement in Enum.GetValues<Supplement>())
            meta[supplement] = Meta424.Create(supplement);

        this.meta = meta.ToFrozenDictionary();
    }
}
