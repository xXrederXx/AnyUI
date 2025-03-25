using AnyUI.Components;
using AnyUI.Components.Util;
using AnyUI.Styling;

namespace AnyUI;

class Program
{
    static Style style = new();
    [STAThread] // Required for WPF
    static void Main(string[] args)
    {
        AnyWindow anyWindow = new();

        style.Size.Value = new(300);
        style.Position.Value = new(100);
        style.BorderThickness.Value = new(10);
        style.CornerRadius.Value = new(100);

        BaseComponent outer = new() { Style = style };
        _ = ChangeRadius();

        anyWindow.AddChild(outer);
        anyWindow.Run();
    }
    static async Task ChangeRadius()
    {
        await Task.Delay(1000);
        style.CornerRadius.Value = new(style.CornerRadius.Value.TopRight / 100 * 90);
    }
}
