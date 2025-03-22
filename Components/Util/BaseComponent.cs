using System.Numerics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using AnyUI.Styling;
using AnyUI.Utility.Extensions;

namespace AnyUI.Components.Util;

public class BaseComponent : ChildRenderer
{
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
        Style = new();
    }

    public UIElement GenerateUIElement()
    {
        _canvas.Width = Style.Size.Value.X;
        _canvas.Height = Style.Size.Value.Y;
        _canvas.Background = Style.BackgroundColor.Value;
        // Apply Clipping to Canvas to match the Border's rounded corners
        _canvas.Clip = new RectangleGeometry()
        {
            Rect = new Rect(0, 0, Style.Size.Value.X, Style.Size.Value.Y),
            RadiusX = Style.CornerRadius.Value.MaxRadius(), // Match the border's CornerRadius
            RadiusY = Style.CornerRadius.Value.MaxRadius(),
        };
        Border innerBorder = new Border()
        {
            CornerRadius = Style.CornerRadius.Value,
            BorderThickness = Style.BorderThickness.Value,
            BorderBrush = Style.BackgroundColor.Value,
            Background = Style.BackgroundColor.Value,
            Child = _canvas,
        };
        Border outerBorder = new Border()
        {
            CornerRadius = Style.CornerRadius.Value,
            BorderThickness = Style.BorderThickness.Value,
            BorderBrush = Style.BorderColor.Value,
            Background =Style.BorderColor.Value,
            Child = innerBorder,
        };
        return outerBorder;
    }
}
