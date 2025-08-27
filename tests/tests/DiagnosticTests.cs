namespace Arinc424.Tests;

public abstract class DiagnosticTests : BaseTests
{
    protected T GetDiagnostic<T>(string file, Supplement supplement)
        where T : Diagnostic
    {
        string[] strings = File.ReadAllLines($"{Diagnostics}{file}");

        _ = Data424.Create(meta[supplement], strings, out string[] _, out var invalid);

        var (_, diagnostic) = invalid.First();

        return (T)diagnostic.First();
    }
}
