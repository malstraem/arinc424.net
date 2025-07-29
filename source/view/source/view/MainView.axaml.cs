using Avalonia.Controls;

namespace Arinc424.View;

public partial class MainView : UserControl
{
    public MainView()
    {
        InitializeComponent();

        DataContext = App.Current.ViewModel;
    }
}
