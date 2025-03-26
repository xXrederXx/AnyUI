using System.Numerics;
using System.Windows;
using System.Windows.Media;
using AnyUI.Components.Util;
using AnyUI.Utility.Types;

namespace AnyUI.Styling;

public class Style
{
    public readonly StyleVar<Vector2> Size;
    public readonly StyleVar<Vector2> Position;
    public readonly StyleVar<Brush> BackgroundColor;
    public readonly StyleVar<Brush> BorderColor;
    public readonly StyleVar<CornerRadius> CornerRadius;
    public readonly StyleVar<Thickness> BorderThickness;
    public readonly StyleVar<Brush> TextColor;
    public readonly StyleVar<Font> Font;
    public Action? OnStyleChanged;

    public Style(
        Vector2? Size = null,
        Vector2? Position = null,
        Brush? BackgroundColor = null,
        Brush? BorderColor = null,
        CornerRadius? CornerRadius = null,
        Thickness? BorderThickness = null,
        Brush? TextColor = null,
        Font? Font = null
    )
    {
        this.Size = new(false, Size ?? new(20));
        this.Position = new(false, Position ?? new(0));
        this.BackgroundColor = new(false, BackgroundColor ?? new SolidColorBrush(Colors.White));
        this.BorderColor = new(false, BorderColor ?? new SolidColorBrush(Colors.Transparent));
        this.CornerRadius = new(false, CornerRadius ?? new(0));
        this.BorderThickness = new(false, BorderThickness ?? new(0));
        this.TextColor = new(true, TextColor ?? new SolidColorBrush(Colors.Black));
        this.Font = new(
            true,
            Font
                ?? new(
                    new FontFamily("Arial"),
                    12,
                    FontStyles.Normal,
                    FontWeights.Normal,
                    FontStretches.Normal
                )
        );

        SubscribeActions();
    }

    private void SubscribeActions()
    {
        void ToCall()
        {
            OnStyleChanged?.Invoke();
        }

        Size.OnChanged += ToCall;
        Position.OnChanged += ToCall;
        BackgroundColor.OnChanged += ToCall;
        BorderColor.OnChanged += ToCall;
        CornerRadius.OnChanged += ToCall;
        BorderThickness.OnChanged += ToCall;
        TextColor.OnChanged += ToCall;
        Font.OnChanged += ToCall;
    }

    public void UpdateInheritValues(BaseComponent? parent)
    {
        if (parent is null)
        {
            return;
        }
        Size.UpdateStyleVar(parent.Style.Size);
        Position.UpdateStyleVar(parent.Style.Position);
        BackgroundColor.UpdateStyleVar(parent.Style.BackgroundColor);
        BorderColor.UpdateStyleVar(parent.Style.BorderColor);
        CornerRadius.UpdateStyleVar(parent.Style.CornerRadius);
        BorderThickness.UpdateStyleVar(parent.Style.BorderThickness);
        TextColor.UpdateStyleVar(parent.Style.TextColor);
        Font.UpdateStyleVar(parent.Style.Font);
    }
}
