using System.Numerics;
using System.Windows;
using System.Windows.Controls;
using AnyUI.Styling;
using AnyUI.Utility.Extensions;

namespace AnyUI.Components.Util;

public class BaseComponent : ChildRenderer
{
    public string Uid { get; private set; } = string.Empty;
    public UIElement? LastGenerated { get; protected set; }

    private BaseComponent? parent;
    public BaseComponent? Parent
    {
        get { return parent; }
        set
        {
            parent = value;
            if (parent is null)
                return;
            Style.UpdateInheritValues(parent);
        }
    }

    private Styling.Style style;
    public Styling.Style Style
    {
        get { return style; }
        protected set
        {
            if (style is not null)
            {
                style.OnStyleChanged -= () => parent?.ReRender();
            }
            style = value;
            style.OnStyleChanged += () => parent?.ReRender();
        }
    }

    protected string uidPrefix;

#pragma warning disable CS8618 // Will get assigned
    public BaseComponent()
    {
        if (Style is null)
        {
            Style = new();
        }
    }
#pragma warning restore CS8618

    public virtual UIElement GenerateUIElement()
    {
        Vector2 size = Style.Size;
        CornerRadius cornerRadius = Style.CornerRadius;

        Canvas.Width = size.X;
        Canvas.Height = size.Y;

        Canvas.Background = Style.BackgroundColor;
        Canvas.Clip = cornerRadius.GenerateClip(Canvas.Width, Canvas.Height);

        Border border = new()
        {
            CornerRadius = Style.CornerRadius,
            BorderThickness = Style.BorderThickness,
            BorderBrush = Style.BorderColor,
            Background = Style.BorderColor,
            Child = Canvas,
        };

        UIElement element = border;
        FinishUIElementGeneration();

        string uid = element.GetHashCode().ToString();
        element.Uid = uidPrefix + uid;
        Uid = uid;

        LastGenerated = element;
        return element;
    }

    public void Reset()
    {
        Canvas = new Canvas();
    }

    protected virtual void FinishUIElementGeneration() { }
}
