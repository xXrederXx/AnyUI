using System.Numerics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using AnyUI.Components.Util;

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
    
    private Button GenerateButton()
    {
        Button button = new Button();
        Vector2 size = Style.Size;

        button.Width = size.X;
        button.Height = size.Y;

        button.Background = Style.BackgroundColor;
        button.Content = Text;

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
