namespace Arinc424.Tests;

/// <summary>
/// Checks entire runtime compilation integrity supplements.
/// </summary>
public class IntegrityTests
{
    [Fact]
    public void CheckSupplements()
    {
        foreach (object value in typeof(Supplement).GetEnumValues())
            _ = new Meta424((Supplement)value);
    }
}
