using AnyUI.Components;
using AnyUI.Components.Util;
using AnyUI.Styling;

namespace AnyUI;

class Program
{
    static AnyWindow anyWindow = new();

    [STAThread] // Required for WPF
    static void Main(string[] args)
    {
        Style style = new();
        style.Size.Value = new(300);
        style.Position.Value = new(100);
        style.BorderThickness.Value = new(10);
        style.CornerRadius.Value = new(200, 20, 4, 50);

        Style style2 = new();
        style2.Size.Value = new(200, 50);
        style2.BorderThickness.Value = new(1);
        style2.CornerRadius.Value = new(4);

        BaseComponent outer = new() { Style = style };
        AnyLabel anyLabel = new() { Style = style2 };
        outer.AddChild(anyLabel);
        anyWindow.AddChild(outer);
        anyWindow.Run();
    }

}
