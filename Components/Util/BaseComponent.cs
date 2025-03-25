using System.Numerics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using AnyUI.Styling;
using AnyUI.Utility.Extensions;

namespace AnyUI.Components.Util;

public class BaseComponent : ChildRenderer
{
    public string Uid { get; private set; } = string.Empty;
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
    public Styling.Style Style;

    public BaseComponent()
    {
        if (Style is null)
        {
            Style = new();
        }
    }

    public UIElement GenerateUIElement()
    {
        Vector2 size = Style.Size;
        CornerRadius cornerRadius = Style.CornerRadius;

        canvas.Width = size.X;
        canvas.Height = size.Y;

        canvas.Background = Style.BackgroundColor;
        // Apply Clipping to Canvas to match the Border's rounded corners
        canvas.Clip = new RectangleGeometry()
        {
            Rect = new Rect(0, 0, size.X, size.Y),
            RadiusX = cornerRadius.MaxRadius(), // Match the border's CornerRadius
            RadiusY = cornerRadius.MaxRadius(),
        };
        Border innerBorder = new()
        {
            CornerRadius = Style.CornerRadius,
            BorderThickness = Style.BorderThickness,
            BorderBrush = Style.BackgroundColor,
            Background = Style.BackgroundColor,
            Child = canvas,
        };
        Border outerBorder = new()
        {
            CornerRadius = Style.CornerRadius,
            BorderThickness = Style.BorderThickness,
            BorderBrush = Style.BorderColor,
            Background = Style.BorderColor,
            Child = innerBorder,
        };
        UIElement element = FinishUIElementGeneration(outerBorder);
        string uid = element.GetHashCode().ToString();
        element.Uid = uid;
        Uid = uid;
        return element;
    }

    protected virtual UIElement FinishUIElementGeneration(UIElement element)
    {
        return element;
    }
}
