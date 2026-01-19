using System.Collections;
using System.Collections.Frozen;
using System.Text.Json;

namespace Arinc424.Tests;

public class RecordRegressionTests : BaseTests
{
    [Test]
    //[Skip("manual")]
    [Arguments("worldwide", Supplement.V18)]
    [Arguments("faa-07.08.25", Supplement.V18)]
    [Arguments("supplement-18", Supplement.V18)]
    public void MakeRegression(string file, Supplement supplement)
    {
        Dictionary<string, int> counts = [];

        Dictionary<string, string[]> invalid = []; // source string <-> type names of diagnostics

        string[] strings = File.ReadAllLines($"{Cases}{file}");

        var data = Data424.Create(meta[supplement], strings, out string[] _, out var inv);

        foreach (var (record, diagnostics) in inv)
            invalid[record.Source!] = diagnostics.Select(x => x.GetType().FullName).ToArray()!;

        foreach (var property in typeof(Data424).GetProperties().Where(x => x.PropertyType.IsArray))
            counts.Add(property.Name, ((Array)property.GetValue(data)!).Length);

        Regression regression = new() { Invalid = invalid.ToFrozenDictionary(), Counts = counts.ToFrozenDictionary() };

        string biba = JsonSerializer.Serialize(regression, options);

        File.WriteAllText($"{Regressions}{file}.json", JsonSerializer.Serialize(regression, options));
    }

    [Test]
    [Arguments("worldwide", Supplement.V18)]
    [Arguments("faa-07.08.25", Supplement.V18)]
    [Arguments("supplement-18", Supplement.V18)]
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
