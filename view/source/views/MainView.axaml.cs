using Arinc424.ViewModels;

using Avalonia.Controls;
using Avalonia.Input;

namespace Arinc424.Views;

public partial class MainView : UserControl
{
    private readonly MainViewModel viewModel = new();

    public MainView()
    {
        InitializeComponent();

        DataContext = viewModel;

        AddHandler(DragDrop.DropEvent, OnDrop);
    }

    private async void OnDrop(object? sender, DragEventArgs e)
    {
        var files = e.Data.GetFiles();

        if (files is null)
            return;

        Data424? data = null;

        await Task.Run(() =>
        {
            string[] strings = File.ReadAllLines(files.First().Path.AbsolutePath);

            data = Data424.Create(strings, Supplement.V18);
        });

        if (data is null)
            return;

        foreach (var airport in data.Airports)
            viewModel.Airports.Add(airport);
    }
}
