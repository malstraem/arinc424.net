using System.Collections;
using System.Text.Json;

namespace Arinc424.Tests;

public class RecordCountRegressionTests
{
    private readonly JsonSerializerOptions options = new() { WriteIndented = true };

#pragma warning disable xUnit1004
    [Theory(Skip = "manual")]
    [InlineData("unknown", Supplement.V18)]
    [InlineData("faa-24.04.18", Supplement.V18)]
    [InlineData("supplement-18", Supplement.V18)]
#pragma warning restore xUnit1004
    public void MakeRegression(string file, Supplement supplement)
    {
        var data = Data424.Create(File.ReadAllLines($"data/{file}"), supplement);

        Dictionary<string, int> counts = [];

        foreach (var property in typeof(Data424).GetProperties().Where(x => x.PropertyType.IsGenericType))
            counts.Add(property.Name, ((ICollection)property.GetValue(data)!).Count);

        File.WriteAllText($"data/regression/{Path.GetFileName($"data/{file}")}.json", JsonSerializer.Serialize(counts, options));
    }

    [Theory]
    [InlineData("unknown", Supplement.V18)]
    [InlineData("faa-24.04.18", Supplement.V18)]
    [InlineData("supplement-18", Supplement.V18)]
    public void CheckRegression(string file, Supplement supplement)
    {
        var data = Data424.Create(File.ReadAllLines($"data/{file}"), supplement);

        var counts = JsonSerializer.Deserialize<Dictionary<string, int>>(File.ReadAllText($"data/regression/{file}.json"))!;

        foreach (var (propertyName, expected) in counts)
        {
            int count = ((ICollection)typeof(Data424).GetProperty(propertyName)!.GetValue(data)!).Count;

            if (count != expected)
                Assert.Fail($"'{propertyName}' regression - expected: {expected}, actual: {count}");
        }
    }
}