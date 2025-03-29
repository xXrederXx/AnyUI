using System.Windows.Media;
using AnyUI.Components;
using AnyUI.Components.Util;

namespace AnyUI;

internal class Program
{
    private static AnyWindow anyWindow;

    [STAThread] // Required for WPF
    private static void Main(string[] args)
    {
        anyWindow = new();

        BaseComponent outer = new();
        outer.Style.Size.Value = new(300);
        outer.Style.Position.Value = new(100);
        outer.Style.BorderThickness.Value = new(10);
        outer.Style.CornerRadius.Value = new(20, 20, 4, 50);
        outer.Style.BorderColor.Value = new SolidColorBrush(Colors.Black);
        outer.Style.TextColor.Value = new SolidColorBrush(Colors.Red);

        AnyLabel anyLabel = new();
        anyLabel.Style.Size.Value = new(200, 50);
        anyLabel.Style.Position.Value = new(10);
        anyLabel.Style.RenderMode.Value = Utility.Types.RenderMode.Fixed;
        anyLabel.Style.BorderThickness.Value = new(1);
        anyLabel.Style.CornerRadius.Value = new(4);
        anyLabel.Text = "A looong text xD xD";

        AnyButton anyButton = new();
        anyButton.OnClick += () => anyWindow.Style.BackgroundColor.Value = new SolidColorBrush(Colors.Orange);
        anyButton.Style.Position.Value = new(0, 10);

        outer.AddChild(anyLabel);
        anyWindow.AddChild(outer);
        anyWindow.AddChild(anyButton);
        anyWindow.Run();
    }
}
