namespace Arinc424.ViewModel;

using Model;

public class RecordViewModel(PropertyModel[] properties, RangeModel[] ranges)
{
    public PropertyModel[] Properties { get; } = properties;

    public RangeModel[] Ranges { get; } = ranges;
}
