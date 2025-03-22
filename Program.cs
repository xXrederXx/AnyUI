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

        BaseComponent outer = new BaseComponent() {
            Style = style,
        };
        BaseComponent inner = new BaseComponent();
        
        outer.AddChild(inner);
        anyWindow.AddChild(outer);
        anyWindow.Run();
    }
}
