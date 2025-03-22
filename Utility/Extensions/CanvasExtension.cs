using System;
using System.Windows;
using System.Windows.Controls;
using AnyUI.Components.Util;

namespace AnyUI.Utility.Extensions;

public static class CanvasExtension
{
    public static void PlaceChild(this Canvas canvas, BaseComponent child)
    {
        // Ensure the element is added to the canvas
        UIElement uIElement = child.GenerateUIElement();
        if (!canvas.Children.Contains(uIElement))
        {
            canvas.Children.Add(uIElement);
        }

        // Set absolute position
        Canvas.SetLeft(uIElement, child.Position.X);
        Canvas.SetTop(uIElement, child.Position.Y);
    }
}
