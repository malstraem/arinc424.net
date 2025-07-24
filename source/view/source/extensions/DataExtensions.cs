using Arinc424.ViewModels;

namespace Arinc424.View;

public static class DataExtensions
{
    public static SubsectionViewModel GetViewModel<T>(this IEnumerable<T> records, string name)
        where T : Record424 => new(name, typeof(T), records);
}
