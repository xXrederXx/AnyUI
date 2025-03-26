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

    public Style(
        Vector2? Size = null,
        Vector2? Position = null,
        Brush? BackgroundColor = null,
        Brush? BorderColor = null,
        CornerRadius? CornerRadius = null,
        Thickness? BorderThickness = null
    )
    {
        this.Size = new(false, Size ?? new(20));
        this.Position = new(false, Position ?? new(0));
        this.BackgroundColor = new(false, BackgroundColor ?? new SolidColorBrush(Colors.White));
        this.BorderColor = new(false, BorderColor ?? new SolidColorBrush(Colors.Transparent));
        this.CornerRadius = new(false, CornerRadius ?? new(0));
        this.BorderThickness = new(false, BorderThickness ?? new(0));
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
