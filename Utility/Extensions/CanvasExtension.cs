using System.Numerics;
using System.Windows;
using System.Windows.Controls;
using AnyUI.Components;
using AnyUI.Components.Util;
using AnyUI.Utility.Types;

namespace AnyUI.Utility.Extensions;

public static class CanvasExtension
{
    public static void PlaceChild(this Canvas canvas, BaseComponent child)
    {
        // Ensure the element is added to the canvas
        UIElement element = child.GenerateUIElement();
        switch (child.Style.RenderMode.Value)
        {
            case RenderMode.Fixed:
                RenderFixed(child, element);
                break;
            case RenderMode.Relativ:
                RenderRelativ(canvas, child, element);
                break;
            case RenderMode.Auto:
                System.Console.WriteLine("No implementation, will use mode RELATIV");
                RenderRelativ(canvas, child, element);
                break;
        }
    }

    private static void RenderRelativ(Canvas canvas, BaseComponent child, UIElement element)
    {
        if (!canvas.Children.Contains(element))
        {
            canvas.Children.Add(element);
        }

        Vector2 childPosition = child.Style.Position;
        Canvas.SetLeft(element, childPosition.X);
        Canvas.SetTop(element, childPosition.Y);
    }

    private static void RenderFixed(BaseComponent child, UIElement element)
    {
        // Set absolute position
        if (AnyWindow.instance is null)
        {
            System.Console.WriteLine("AnyWindow.instance is null, will NOT render");
            return;
        }
        Canvas canvas = AnyWindow.instance.Canvas;
        if (!canvas.Children.Contains(element))
        {
            canvas.Children.Add(element);
        }
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
