using System.Numerics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using AnyUI.Components.Util;

namespace AnyUI.Components;

public class AnyLabel : BaseComponent
{
    protected override UIElement FinishUIElementGeneration(UIElement element)
    {
        Label label = new Label();
        Vector2 size = Style.Size;
        label.Width = size.X;
        label.Height = size.Y;
        label.Background = new SolidColorBrush(Colors.Beige);
        label.Content = "This is a looong text xD";
        canvas.Children.Add(label);
        return element;
    }
}
