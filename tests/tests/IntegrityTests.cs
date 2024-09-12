namespace Arinc424.Tests;

/// <summary>
/// Checks entire runtime compilation integrity for all supplements.
/// </summary>
public class IntegrityTests
{
    [Fact]
    public void CheckSupplements()
    {
        foreach (var value in Enum.GetValues<Supplement>())
            _ = new Meta424(value);
    }
}
