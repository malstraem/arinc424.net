using System.Collections.Frozen;

namespace Arinc424.Tests;

public class DiagnosticTests
{
    private readonly FrozenDictionary<Supplement, Meta424> meta;

    public DiagnosticTests()
    {
        Dictionary<Supplement, Meta424> meta = [];

        foreach (var supplement in Enum.GetValues<Supplement>())
            meta[supplement] = Meta424.Create(supplement);

        this.meta = meta.ToFrozenDictionary();
    }

    [Test]
    [Arguments("strong", Supplement.V20)]
    public void Strong(string file, Supplement supplement)
    {
        string[] strings = File.ReadAllLines($"{Diagnostics}{file}");

        var data = Data424.Create(meta[supplement], strings, out string[] _, out var invalid);

        var diagnostics = invalid.Values.SelectMany(x => x);

        foreach (var diagnostic in diagnostics)
        {
            if (diagnostic is BadKnown bad && bad.Error is LinkError.KeyNotFound)
                continue;

            Assert.Fail("");
        }
    }
}
