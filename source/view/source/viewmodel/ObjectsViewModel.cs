using System.Reflection;

namespace Arinc424.ViewModel;

using Model;
using Attributes;

public partial class ObjectsViewModel(RecordModel[] records, string name) : ObservableObject
{
    private RecordModel? selected;

    [ObservableProperty]
    private RecordViewModel? selectedViewModel;

    public string Name { get; } = name;

    public IEnumerable<RecordModel> Records { get; } = records;

    [Obsolete("TODO supplement versioning")]
    public RecordModel? Selected
    {
        get => selected;
        set
        {
            if (SetProperty(ref selected, value) && value is not null)
            {
                var source = value.Record.Source.AsMemory();

                List<RangeModel> ranges = [];
                List<PropertyModel> properties = [];

                foreach (var property in value.Record.GetType().GetProperties())
                {
                    if (property.PropertyType.IsArray || property.Name == nameof(Record424.Source))
                        continue;

                    var range = property.GetCustomAttributes<RangeAttribute>().FirstOrDefault(); // TODO supplement versioning

                    if (range is not null)
                    {
                        ranges.Add(new(range.Range, source[range.Range]));
                        properties.Add(new(property.Name, property.GetValue(value.Record)));
                    }
                }
                SelectedViewModel = new([.. properties], [.. ranges]);
            }
        }
    }
}
