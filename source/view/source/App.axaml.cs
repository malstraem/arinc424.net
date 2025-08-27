using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Avalonia.Input;

namespace Arinc424.View;

using ViewModel;

public partial class App : Application
{
    private void OnDrop(object? sender, DragEventArgs e)
    {
        var files = e.Data.GetFiles();

        if (files is null)
            return;

        ViewModel.Load(files.Select(x => x.Path.LocalPath).ToArray());
    }

    public override void Initialize() => AvaloniaXamlLoader.Load(this);

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow();
            desktop.MainWindow.AddHandler(DragDrop.DropEvent, OnDrop);
        }
        else if (ApplicationLifetime is ISingleViewApplicationLifetime platform)
        {
            platform.MainView = new MainView();
            platform.MainView.AddHandler(DragDrop.DropEvent, OnDrop);
        }
        base.OnFrameworkInitializationCompleted();
    }

    public static new App Current => (App)Application.Current!;

    public DataViewModel ViewModel { get; } = new();
}
