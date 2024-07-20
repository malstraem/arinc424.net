using System.Collections.ObjectModel;

using Arinc424.Ports;

namespace Arinc424.ViewModels;

public class MainViewModel : ViewModelBase
{
    public string Greeting => "drop your data";

    public ObservableCollection<Airport> Airports { get; } = [];
}
