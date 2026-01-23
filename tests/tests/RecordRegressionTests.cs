using System.Collections;
using System.Text.Json;

namespace Arinc424.Tests;

public class RecordRegressionTests : BaseTests
{
    [Test]
    [Skip("manual")]
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

        Regression regression = new() { Invalid = invalid, Counts = counts };

        File.WriteAllText($"{Regressions}{file}.json", JsonSerializer.Serialize(regression, options));
    }

    [Test]
    [Arguments("worldwide", Supplement.V18)]
    [Arguments("faa-07.08.25", Supplement.V18)]
    [Arguments("supplement-18", Supplement.V18)]
    public async Task CheckRegression(string file, Supplement supplement)
    {
        var regression = JsonSerializer.Deserialize<Regression>(File.ReadAllText($"{Regressions}{file}.json"), options)!;

        string[] strings = File.ReadAllLines($"{Cases}{file}");

        var data = Data424.Create(meta[supplement], strings, out _, out var invalid);

        foreach (var (propertyName, expected) in regression.Counts)
        {
            int count = ((ICollection)typeof(Data424).GetProperty(propertyName)!.GetValue(data)!).Count;

            if (count != expected)
                Assert.Fail($"'{propertyName}' regression - expected: {expected}, actual: {count}");
        }

        foreach (var (record, diagnostics) in invalid)
        {
            if (!regression.Invalid.TryGetValue(record.Source!, out string[]? expected))
                Assert.Fail($"'{file}' regression - source '{record.Source!}' is not found.");

            if (diagnostics.Length != expected!.Length)
                Assert.Fail($"'{file}' regression - diagnsotics count is not equal to previos.");
        }
    }
}
