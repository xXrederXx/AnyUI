using System.Windows.Media;
using AnyUI.Components;

namespace AnyUI.TestApps;

public class BasicTest
{
    public BasicTest()
    {
        AnyWindow window = new();

        window.Style.Size.Value = new (300);
        window.Style.BackgroundColor.Value = new SolidColorBrush(Colors.LightGray);

        AnyLabel label = new();
        label.Text = "Hello, Click The button";
        label.Style.Position.Value = new (20, 5);
        
        AnyButton button = new();
        button.Style.Position.Value = new (0, 40);
        window.AddChild(label);
        window.AddChild(button);

        window.Run();
    }
}
