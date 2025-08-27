namespace Arinc424.Model;

public class PropertyModel(string name, object? value)
{
    public string Name { get; } = name;

    public object? Value { get; } = value;
}
