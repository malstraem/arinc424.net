using System.Collections;
using System.Text.Json;

namespace Arinc424.Tests;

public class RegressionTests
{
#pragma warning disable xUnit1004
    [Fact(Skip = "manual")]
#pragma warning restore xUnit1004
    public void MakeRegression()
    {
        foreach (string path in Directory.GetFiles("data"))
        {
            var data = Data424.Load(File.ReadAllLines(path));

            Dictionary<string, int> counts = [];

            foreach (var property in typeof(Data424).GetProperties().Where(x => x.PropertyType.IsGenericType))
                counts.Add(property.Name, ((ICollection)property.GetValue(data)!).Count);

            File.WriteAllText($"data/{Path.GetFileName(path)}.json", JsonSerializer.Serialize(counts));
        }
    }

    [Theory]
    [InlineData("case-1")]
    [InlineData("case-2")]
    [InlineData("faa-230223")]
    public void Load(string file)
    {
        var data = Data424.Load(File.ReadAllLines($"data/{file}"));

        var counts = JsonSerializer.Deserialize<Dictionary<string, int>>(File.ReadAllText($"data/regression/{file}.json"))!;

        foreach (var (propertyName, count) in counts)
            Assert.Equal(count, ((ICollection)typeof(Data424).GetProperty(propertyName)!.GetValue(data)!).Count);
    }
}