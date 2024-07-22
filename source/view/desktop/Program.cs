using Avalonia;

namespace Arinc424.View.Desktop;

public class Program
{
    [STAThread]
    public static void Main(string[] args) => BuildAvaloniaApp().StartWithClassicDesktopLifetime(args);

    public static AppBuilder BuildAvaloniaApp() => AppBuilder.Configure<App>()
        .UsePlatformDetect()
            .WithInterFont()
                .LogToTrace();
}
