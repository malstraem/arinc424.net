namespace Arinc424.Model;

using ViewModel;

public partial class SectionModel(string name, IEnumerable<ObjectsViewModel> vewModels)
{
    public string Name { get; } = name;

    public IEnumerable<ObjectsViewModel> VewModels { get; } = vewModels;
}
