namespace Arinc424.Tests;

/**<summary>
Checks runtime compilation integrity for all supplements.
</summary>*/
public class IntegrityTests
{
    [Test]
    public void CheckSupplements()
    {
        foreach (var value in Enum.GetValues<Supplement>())
            _ = Meta424.Create(value);
    }
}
