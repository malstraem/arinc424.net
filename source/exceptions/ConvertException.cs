namespace Arinc424;

public class ConvertException(string @string, string message) : Exception(message)
{
    public string @String { get; } = @string;
}
