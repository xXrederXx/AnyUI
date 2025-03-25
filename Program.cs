using AnyUI.Components;
using AnyUI.Components.Util;
using AnyUI.Styling;

namespace AnyUI;

class Program
{
    static Style style = new();
    static AnyWindow anyWindow = new();

    [STAThread] // Required for WPF
    static void Main(string[] args)
    {
        style.Size.Value = new(300);
        style.Position.Value = new(100);
        style.BorderThickness.Value = new(10);
        style.CornerRadius.Value = new(100);

        BaseComponent outer = new() { Style = style };

        anyWindow.AddChild(outer);
        anyWindow.Run();
    }

}
