using System.Numerics;
using System.Windows.Controls;
using AnyUI.Styling;
using AnyUI.Utility.Types;

namespace AnyUI.Utility.UI;

public static class WPFHelper
{
    public static T ApplyBaseStyle<T>(T element, Style style) where T : ContentControl
    {
        Vector2 size = style.Size;
        Font font = style.Font;

        element.Width = size.X;
        element.Height = size.Y;

        element.Background = style.BackgroundColor;
        element.Foreground = style.TextColor;

        element.FontFamily = font.Family;
        element.FontSize = font.Size;
        element.FontStretch = font.Stretch;
        element.FontStyle = font.Style;
        element.FontWeight = font.Weight;


        return element;
    }
}
