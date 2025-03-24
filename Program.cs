using AnyUI.Components;
using AnyUI.Components.Util;
using AnyUI.Styling;

namespace AnyUI;
class Program
{
    [STAThread] // Required for WPF
    static void Main(string[] args)
    {
        AnyWindow anyWindow = new AnyWindow();
        Style style = new Style();
        style.Size.Value = new (300);
        style.Position.Value = new(100);
        style.BorderThickness.Value = new(10);

        Style style2 = new Style();
        style2.Size.Value = new (400);
        style2.Position.Value = new(500, 700);
        style2.BorderThickness.Value = new(0, 0, 20, 20);

        BaseComponent outer = new BaseComponent() {
            Style = style,
        };
        BaseComponent inner = new BaseComponent();

        BaseComponent far = new BaseComponent() {
            Style = style2,
        };
        
        outer.AddChild(inner);
        anyWindow.AddChild(outer);
        anyWindow.AddChild(far);
        anyWindow.Run();
    }
}
