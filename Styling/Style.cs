using System.Numerics;
using System.Windows;
using System.Windows.Media;
using AnyUI.Components.Util;

namespace AnyUI.Styling;

public class Style
{
    public readonly StyleVar<Vector2> Size;
    public readonly StyleVar<Vector2> Position;
    public readonly StyleVar<Brush> BackgroundColor;
    public readonly StyleVar<Brush> BorderColor;
    public readonly StyleVar<CornerRadius> CornerRadius;
    public readonly StyleVar<Thickness> BorderThickness;

    public Style()
    {
        Size = new(false, new Vector2(10));
        Position = new(false, new Vector2(0));
        BackgroundColor = new(false, new SolidColorBrush(Colors.White));
        BorderColor = new(false, new SolidColorBrush(Colors.Black));
        CornerRadius = new(false, new CornerRadius(4));
        BorderThickness = new(false, new Thickness(2));
    }
    public void UpdateInheritValues(BaseComponent parent)
    {
        Size.UpdateStyleVar(parent.Style.Size);
        Position.UpdateStyleVar(parent.Style.Position);
        BackgroundColor.UpdateStyleVar(parent.Style.BackgroundColor);
        BorderColor.UpdateStyleVar(parent.Style.BorderColor);
        CornerRadius.UpdateStyleVar(parent.Style.CornerRadius);
        BorderThickness.UpdateStyleVar(parent.Style.BorderThickness);
    }
}
