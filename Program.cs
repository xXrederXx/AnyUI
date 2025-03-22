using AnyUI.Components;
using AnyUI.Components.Util;

namespace AnyUI;
class Program
{
    [STAThread] // Required for WPF
    static void Main(string[] args)
    {
        AnyWindow anyWindow = new AnyWindow();

        BaseComponent test = new BaseComponent() {
            Size = new (300),
            Position = new (10)
        };
        BaseComponent test2 = new BaseComponent() {
            Size = new (100),
            Position = new (50)
        };
        test.AddChild(test2);
        anyWindow.AddChild(test);
        anyWindow.Run();
    }
}
