using System.Numerics;
using System.Windows;
using System.Windows.Controls;
using AnyUI.Components.Util;

namespace AnyUI.Components;

public class AnyLabel : BaseComponent
{
    public string Text = "AnyLabel";
    public AnyLabel()
    {
        Style = new Styling.Style(
            Size: new Vector2(200, 24)
        );
    }
    private Label GenerateLabel()
    {
        Label label = new Label();
        Vector2 size = Style.Size;

        label.Width = size.X;
        label.Height = size.Y;

        label.Background = Style.BackgroundColor;
        label.Content = Text;

        return label;
    }
    protected override UIElement FinishUIElementGeneration(UIElement element)
    {
        
        canvas.Children.Add(GenerateLabel());
        return element;
    }
}
