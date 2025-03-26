using System.Numerics;
using System.Windows;
using System.Windows.Controls;
using AnyUI.Components.Util;
using AnyUI.Utility.Types;

namespace AnyUI.Components;

public class AnyLabel : BaseComponent
{
    public string Text = "AnyLabel";

    public AnyLabel()
    {
        Style = new Styling.Style(Size: new Vector2(200, 24));
    }

    public AnyLabel(Styling.Style style)
    {
        Style = style;
    }

    private Label GenerateLabel()
    {
        Label label = new Label();
        Vector2 size = Style.Size;
        Font font = Style.Font;

        label.Width = size.X;
        label.Height = size.Y;

        label.FontFamily = font.Family;
        label.FontSize = font.Size;
        label.FontStretch = font.Stretch;
        label.FontStyle = font.Style;
        label.FontWeight = font.Weight;
        label.Foreground = Style.TextColor;

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
