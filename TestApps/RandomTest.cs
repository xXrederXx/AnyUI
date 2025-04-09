using System;
using System.Windows.Media;
using AnyUI.Components;
using AnyUI.Components.Util;

namespace AnyUI.TestApps;

public class RandomTest
{
    private AnyWindow anyWindow;

    public RandomTest()
    {
        anyWindow = new();

        BaseComponent outer = new();
        outer.Style.Size.Set(new(300));
        outer.Style.Position.Set(new(100));
        outer.Style.BorderThickness.Set(new(10));
        outer.Style.CornerRadius.Set(new(20, 20, 4, 50));
        outer.Style.BorderColor.Set(new SolidColorBrush(Colors.Black));
        outer.Style.TextColor.Set(new SolidColorBrush(Colors.Red));

        AnyLabel anyLabel = new();
        anyLabel.Style.Size.Set(new(200, 50));
        anyLabel.Style.Position.Set(new(10));
        anyLabel.Style.RenderMode.Set(Utility.Types.RenderMode.Fixed);
        anyLabel.Style.BorderThickness.Set(new(1));
        anyLabel.Style.CornerRadius.Set(new(4));
        anyLabel.Text = "A looong text xD xD";

        AnyButton anyButton = new();
        anyButton.OnClick += () => anyWindow.Style.BackgroundColor.Set(new SolidColorBrush(Colors.Orange));
        anyButton.Style.Position.Set(new(0, 10));

        outer.AddChild(anyLabel);
        anyWindow.AddChild(outer);
        anyWindow.AddChild(anyButton);
        anyWindow.Run();
    }
}
