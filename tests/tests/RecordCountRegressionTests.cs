using System.Collections;
using System.Collections.Frozen;
using System.Text.Json;

namespace Arinc424.Tests;

public class RecordCountRegressionTests
{
    private readonly JsonSerializerOptions options = new() { WriteIndented = true };

    private readonly FrozenDictionary<Supplement, Meta424> meta;

    public RecordCountRegressionTests()
    {
        Dictionary<Supplement, Meta424> meta = [];

        foreach (var supplement in Enum.GetValues<Supplement>())
            meta[supplement] = Meta424.Create(supplement);

        this.meta = meta.ToFrozenDictionary();
    }

    [Test]
    [Skip("manual")]
    [Arguments("worldwide", Supplement.V18)]
    [Arguments("faa-07.08.25", Supplement.V18)]
    [Arguments("supplement-18", Supplement.V18)]
    public void MakeRegression(string file, Supplement supplement)
    {
        string[] strings = File.ReadAllLines($"{Cases}{file}");

        var data = Data424.Create(meta[supplement], strings, out string[] _, out var _);

        Dictionary<string, int> counts = [];

        foreach (var property in typeof(Data424).GetProperties().Where(x => x.PropertyType.IsGenericType))
            counts.Add(property.Name, ((ICollection)property.GetValue(data)!).Count);

        File.WriteAllText($"{Regressions}{file}.json", JsonSerializer.Serialize(counts, options));
    }

    [Test]
    [Arguments("worldwide", Supplement.V18)]
    [Arguments("faa-07.08.25", Supplement.V18)]
    [Arguments("supplement-18", Supplement.V18)]
    [Arguments("private/B2508Av20 (CAI)", Supplement.V20)]
    [Arguments("private/2409v20 (CAI)", Supplement.V20)]
    public void CheckRegression(string file, Supplement supplement)
    {
        string[] strings = File.ReadAllLines($"{Cases}{file}");

        var data = Data424.Create(meta[supplement], strings, out string[] _, out var _);

        var counts = JsonSerializer.Deserialize<Dictionary<string, int>>(File.ReadAllText($"{Regressions}{file}.json"))!;

        foreach (var (propertyName, expected) in counts)
        {
            int count = ((ICollection)typeof(Data424).GetProperty(propertyName)!.GetValue(data)!).Count;

            if (count != expected)
                Assert.Fail($"'{propertyName}' regression - expected: {expected}, actual: {count}");
        }
    }
}
