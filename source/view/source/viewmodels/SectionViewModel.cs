namespace Arinc424.ViewModels;

public partial class SectionViewModel(string name, IEnumerable<SubsectionViewModel> subsections) : ObservableObject
{
    public string Name { get; } = name;

    public IEnumerable<SubsectionViewModel> Subsections { get; } = subsections;
}
