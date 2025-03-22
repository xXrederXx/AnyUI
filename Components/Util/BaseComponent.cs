using System.Numerics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using AnyUI.Utility.Extensions;

namespace AnyUI.Components.Util;

public class BaseComponent : ChildRenderer
{
    public BaseComponent? Parent;
    public Vector2 Size;
    public Vector2 Position;
    public Brush BackgroundColor = new SolidColorBrush(Colors.White);
    public Brush BorderColor = new SolidColorBrush(Colors.Green);
    public CornerRadius CornerRadius = new CornerRadius(5, 40, 20, 10);
    public Thickness BorderThickness = new Thickness(4);
    
    public UIElement GenerateUIElement()
    {

        _canvas.Width = Size.X;
        _canvas.Height = Size.Y;
        _canvas.Background= BackgroundColor;
        // Apply Clipping to Canvas to match the Border's rounded corners
        _canvas.Clip = new RectangleGeometry()
        {
            Rect = new Rect(0, 0, Size.X, Size.Y),
            RadiusX = CornerRadius.MaxRadius(), // Match the border's CornerRadius
            RadiusY = CornerRadius.MaxRadius(),
        };
        Border innerBorder = new Border()
        {
            CornerRadius = CornerRadius,
            BorderThickness = BorderThickness,
            BorderBrush = BackgroundColor,
            Background = BackgroundColor,
            Child = _canvas,
        };
        Border outerBorder = new Border()
        {
            CornerRadius = CornerRadius,
            BorderThickness = BorderThickness,
            BorderBrush = BorderColor,
            Background = BorderColor,
            Child = innerBorder,
        };
        return outerBorder;
    }
}
