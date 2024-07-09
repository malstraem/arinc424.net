namespace Arinc424.Tests;

public class IntegrityTests
{
    [Fact]
    public void CheckSupplements()
    {
        foreach (object value in typeof(Supplement).GetEnumValues())
            _ = new Meta424((Supplement)value);
    }
}
