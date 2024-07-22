namespace Arinc424.ViewModels;

public partial class SubsectionViewModel : ObservableObject
{
    private readonly Type type;

    private RecordViewModel? selected;

    [ObservableProperty]
    private IEnumerable<PropertyViewModel>? selectedProperties;

    public SubsectionViewModel(string name, Type type, IEnumerable<Record424> records)
    {
        this.type = type;

        List<RecordViewModel> viewModels = [];

        foreach (var record in records)
            viewModels.Add(new(record));

        Records = viewModels;

        Name = name;
    }

    public string Name { get; }

    public RecordViewModel? Selected
    {
        get => selected;
        set
        {
            if (SetProperty(ref selected, value) && value is not null)
            {
                List<PropertyViewModel> properties = [];

                foreach (var property in type.GetProperties())
                {
                    object? propValue = property.GetValue(value.Record);

                    if (propValue is not null)
                        properties.Add(new PropertyViewModel(property.Name, propValue));
                }
                SelectedProperties = properties;
            }
        }
    }

    public IEnumerable<RecordViewModel> Records { get; }
}
