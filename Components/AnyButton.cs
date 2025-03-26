using System.Numerics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using AnyUI.Components.Util;
using AnyUI.Utility.Types;

namespace AnyUI.Components;

public class AnyButton : BaseComponent
{
    public string Text = "AnyButton";
    public Action? OnClick;

    public AnyButton()
    {
        Style = new Styling.Style(
            Size: new Vector2(200, 50),
            BorderColor: new SolidColorBrush(Colors.Black),
            BorderThickness: new(2),
            CornerRadius: new(4)
        );
    }

    public AnyButton(Styling.Style style)
    {
        Style = style;
    }

    private Button GenerateButton()
    {
        Button button = new Button();
        Vector2 size = Style.Size;
        Font font = Style.Font;

        button.Width = size.X;
        button.Height = size.Y;

        button.Background = Style.BackgroundColor;
        button.Content = Text;

        button.FontFamily = font.Family;
        button.FontSize = font.Size;
        button.FontStretch = font.Stretch;
        button.FontStyle = font.Style;
        button.FontWeight = font.Weight;
        button.Foreground = Style.TextColor;

        if (OnClick != null)
        {
            button.Click += (s, e) => OnClick.Invoke();
        }

        return button;
    }

    protected override UIElement FinishUIElementGeneration(UIElement element)
    {
        canvas.Children.Add(GenerateButton());
        return element;
    }
}
