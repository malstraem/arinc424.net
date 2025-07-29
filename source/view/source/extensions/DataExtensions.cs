namespace Arinc424.View;

using ViewModel;
using Model;

public static class DataExtensions
{
    public static ObjectsViewModel? GetViewModel<T>(this T[] records, string name)
        where T : Record424 => new([.. records.Select(x => new RecordModel(x))], name);
}
