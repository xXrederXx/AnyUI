using System.Numerics;
using System.Windows.Controls;
using System.Windows.Media;
using AnyUI.Components.Util;
using AnyUI.Utility.UI;

namespace AnyUI.Components;

public class AnyLabel : BaseComponent
{
    public string Text = "AnyLabel";

    public AnyLabel()
    {
        Style = new Styling.Style(Size: new Vector2(200, 24), BackgroundColor: new SolidColorBrush(Colors.Transparent));
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
