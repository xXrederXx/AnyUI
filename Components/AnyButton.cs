using System.Numerics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using AnyUI.Components.Util;
using AnyUI.Utility.Types;
using AnyUI.Utility.UI;

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

    private Button generateButton()
    {
        Button button = WPFHelper.ApplyBaseStyle(new Button(), Style);
        button.Content = Text;
        if (OnClick != null)
        {
            button.Click += (s, e) => OnClick.Invoke();
        }

        return button;
    }

    protected override void FinishUIElementGeneration()
    {
        canvas.Children.Add(generateButton());
    }
}
