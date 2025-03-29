using System.Numerics;
using System.Windows;
using System.Windows.Controls;
using AnyUI.Components.Util;
using AnyUI.Utility.Types;
using AnyUI.Utility.UI;

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

    private Label generateLabel()
    {
        Label label = WPFHelper.ApplyBaseStyle(new Label(), Style);
        label.Content = Text;

        return label;
    }

    protected override void FinishUIElementGeneration()
    {
        Canvas.Children.Add(generateLabel());
    }
}
