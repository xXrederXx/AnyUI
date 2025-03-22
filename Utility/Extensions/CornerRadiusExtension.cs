using System;
using System.Windows;

namespace AnyUI.Utility.Extensions;

public static class CornerRadiusExtension
{
    public static double MaxRadius(this CornerRadius radius)
    {
        return MyMath.Max(radius.TopLeft, radius.TopRight, radius.BottomLeft, radius.BottomRight);
    }
}
