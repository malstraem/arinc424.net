namespace Arinc.Spec424;

public class ConvertException(string @string, string message) : Exception(message)
{
    public string @String { get; } = @string;
}
