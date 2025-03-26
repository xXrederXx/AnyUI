using System.Windows.Media;
using AnyUI.Components;
using AnyUI.Components.Util;
using AnyUI.Styling;

namespace AnyUI;

class Program
{
    static readonly AnyWindow anyWindow = new();

    [STAThread] // Required for WPF
    static void Main(string[] args)
    {
        BaseComponent outer = new();
        outer.Style.Size.Value = new(300);
        outer.Style.Position.Value = new(100);
        outer.Style.BorderThickness.Value = new(10);
        outer.Style.CornerRadius.Value = new(20, 20, 4, 50);
        outer.Style.BorderColor.Value = new SolidColorBrush(Colors.Black);
        outer.Style.TextColor.Value = new SolidColorBrush(Colors.Red);

        AnyLabel anyLabel = new();
        anyLabel.Style.Size.Value = new(200, 50);
        anyLabel.Style.BorderThickness.Value = new(1);
        anyLabel.Style.CornerRadius.Value = new(4);
        anyLabel.Text = "A looong text xD xD";

        AnyButton anyButton = new();
        anyButton.OnClick += () => System.Console.WriteLine("Click");
        anyButton.Style.Position.Value = new(0, 10);

        outer.AddChild(anyLabel);
        anyWindow.AddChild(outer);
        anyWindow.AddChild(anyButton);
        anyWindow.Run();
    }
}
