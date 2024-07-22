namespace Arinc424.ViewModels;

public class PropertyViewModel(string name, object value)
{
    public string Name { get; } = name;

    public object Value { get; } = value;
}
