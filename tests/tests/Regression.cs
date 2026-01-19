using System.Collections.Frozen;

namespace Arinc424.Tests;

public class Regression
{
    public required FrozenDictionary<string, int> Counts { get; set; }

    public required FrozenDictionary<string, string[]> Invalid { get; set; }
}
