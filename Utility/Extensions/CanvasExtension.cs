using System.Numerics;
using System.Windows;
using System.Windows.Controls;
using AnyUI.Components.Util;

namespace AnyUI.Utility.Extensions;

public static class CanvasExtension
{
    public static void PlaceChild(this Canvas canvas, BaseComponent child)
    {
        // Ensure the element is added to the canvas
        UIElement element = child.GenerateUIElement();
        if (!canvas.Children.Contains(element))
        {
            canvas.Children.Add(element);
        }

        // Set absolute position
        Vector2 position = child.Style.Position;
        Canvas.SetLeft(element, position.X);
        Canvas.SetTop(element, position.Y);
    }

    public static void RemoveChild(this Canvas canvas, BaseComponent child)
    {
        // Ensure the element is added to the canvas
        UIElement? element = child.LastGenerated;
        if (canvas.Children.Contains(element))
        {
            canvas.Children.Remove(element);
            System.Console.WriteLine("remove");
        }
        else
        {
            System.Console.WriteLine("Cant remove -> " + child.Uid);
        }
    }
}
