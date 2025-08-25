namespace Arinc424.Tests;

public class PolymorphDiagnosticTests : DiagnosticTests
{
    [Test]
    [Arguments("polymorph-null", Supplement.V20, LinkError.Null)]
    [Arguments("polymorph-wrong-type", Supplement.V20, LinkError.WrongType)]
    [Arguments("polymorph-wrong-type (invalid section)", Supplement.V20, LinkError.WrongType)]
    [Arguments("polymorph-key-not-found", Supplement.V20, LinkError.KeyNotFound)]
    [Arguments("polymorph-key-not-found (no one)", Supplement.V20, LinkError.KeyNotFound)]
    public async Task Check(string file, Supplement supplement, LinkError error)
    {
        var bad = GetDiagnostic<BadPolymorph>(file, supplement);

        await Assert.That(bad.Error).IsEqualTo(error);
    }
}
