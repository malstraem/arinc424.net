namespace Arinc424.Tests;

public class StrongTypeDiagnosticTests : DiagnosticTests
{
    [Test]
    [Arguments("strong-null", Supplement.V20, LinkError.Null)]
    [Arguments("strong-key-not-found", Supplement.V20, LinkError.KeyNotFound)]
    [Arguments("strong-key-not-found (no one)", Supplement.V20, LinkError.KeyNotFound)]
    public async Task Check(string file, Supplement supplement, LinkError error)
    {
        var bad = GetDiagnostic<BadKnown>(file, supplement);

        await Assert.That(bad.Error).IsEqualTo(error);
    }
}
