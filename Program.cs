using AnyUI.TestApps;

namespace AnyUI;

internal class Program
{
    [STAThread] // Required for WPF
    private static void Main(string[] args)
    {
        new BasicTest();
    }
}
