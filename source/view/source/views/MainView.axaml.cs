using Arinc424.View;

using Avalonia.Controls;

namespace Arinc424.Views;

public partial class MainView : UserControl
{
    public MainView()
    {
        InitializeComponent();

        DataContext = App.Current.ViewModel;
    }
}
