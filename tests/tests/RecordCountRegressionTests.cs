using System.Collections;
using System.Text.Json;

namespace Arinc424.Tests;

public class RecordCountRegressionTests
{
    [Test]
    //[Skip("manual")]
    [Arguments("worldwide", Supplement.V18)]
    [Arguments("faa-07.08.25", Supplement.V18)]
    [Arguments("supplement-18", Supplement.V18)]
    public void MakeRegression(string file, Supplement supplement)
    {
        var data = Data424.Create(Meta424.Create(supplement), File.ReadAllLines($"data/{file}"), out var _, out var _);

        Dictionary<string, int> counts = [];

        foreach (var property in typeof(Data424).GetProperties().Where(x => x.PropertyType.IsGenericType))
            counts.Add(property.Name, ((ICollection)property.GetValue(data)!).Count);

        JsonSerializerOptions options = new() { WriteIndented = true };

        File.WriteAllText($"data/regression/{Path.GetFileName($"data/{file}")}.json", JsonSerializer.Serialize(counts, options));
    }

    [Test]
    [Arguments("worldwide", Supplement.V18)]
    [Arguments("faa-07.08.25", Supplement.V18)]
    [Arguments("supplement-18", Supplement.V18)]
    public void CheckRegression(string file, Supplement supplement)
    {
        var data = Data424.Create(Meta424.Create(supplement), File.ReadAllLines($"data/{file}"), out var _, out var _);

        var counts = JsonSerializer.Deserialize<Dictionary<string, int>>(File.ReadAllText($"data/regression/{file}.json"))!;

        foreach (var (propertyName, expected) in counts)
        {
            int count = ((ICollection)typeof(Data424).GetProperty(propertyName)!.GetValue(data)!).Count;

            if (count != expected)
                Assert.Fail($"'{propertyName}' regression - expected: {expected}, actual: {count}");
        }
    }
}
