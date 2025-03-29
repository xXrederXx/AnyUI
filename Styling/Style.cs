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
    public readonly StyleVar<Thickness> Margin;
    public readonly StyleVar<Thickness> Padding;
    public readonly StyleVar<RenderMode> RenderMode;
    public Action? OnStyleChanged;

    public Style(
        Vector2? Size = null,
        Vector2? Position = null,
        Brush? BackgroundColor = null,
        Brush? BorderColor = null,
        CornerRadius? CornerRadius = null,
        Thickness? BorderThickness = null,
        Brush? TextColor = null,
        Font? Font = null,
        Thickness? Margin = null,
        Thickness? Padding = null,
        RenderMode? RenderMode = null
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
        this.Margin = new(false, Margin ?? new(0));
        this.Padding = new(false, Padding ?? new(0));
        this.RenderMode = new(false, RenderMode ?? Utility.Types.RenderMode.Auto);

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
        Margin.OnChanged += ToCall;
        Padding.OnChanged += ToCall;
        RenderMode.OnChanged += ToCall;
    }

    public void UpdateInheritValues(BaseComponent? parent)
    {
        if (parent is null)
        {
            return;
        }
        Style style = parent.Style;
        Size.UpdateStyleVar(style.Size);
        Position.UpdateStyleVar(style.Position);
        BackgroundColor.UpdateStyleVar(style.BackgroundColor);
        BorderColor.UpdateStyleVar(style.BorderColor);
        CornerRadius.UpdateStyleVar(style.CornerRadius);
        BorderThickness.UpdateStyleVar(style.BorderThickness);
        TextColor.UpdateStyleVar(style.TextColor);
        Font.UpdateStyleVar(style.Font);
        Margin.UpdateStyleVar(style.Margin);
        Padding.UpdateStyleVar(style.Padding);
        RenderMode.UpdateStyleVar(style.RenderMode);
    }
}
