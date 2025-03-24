using System;
using AnyUI.Components.Util;

namespace AnyUI.Utility.UI;

public static class CalculateDimensions
{
    public static double CalculateHeight(ChildRenderer TopNode)
    {
        double maxValue = double.MinValue;
        foreach (BaseComponent child in TopNode.children)
        {
            double value = RecurisiveHeightCalc(child);
            if (value > maxValue)
            {
                maxValue = value;
            }
        }
        return maxValue;
    }

    private static double RecurisiveHeightCalc(BaseComponent component)
    {
        double maxValue =
            component.Style.Position.Value.Y
            + component.Style.Size.Value.Y
            + component.Style.BorderThickness.Value.Top * 2
            + component.Style.BorderThickness.Value.Bottom * 2;

        foreach (BaseComponent child in component.children)
        {
            double value = RecurisiveHeightCalc(child);
            if (value > maxValue)
            {
                maxValue = value;
            }
        }
        return maxValue;
    }

    public static double CalculateWidth(ChildRenderer TopNode)
    {
        double maxValue = double.MinValue;
        foreach (BaseComponent child in TopNode.children)
        {
            double value = RecurisiveWidthCalc(child);
            if (value > maxValue)
            {
                maxValue = value;
            }
        }
        return maxValue;
    }

    private static double RecurisiveWidthCalc(BaseComponent component)
    {
        double maxValue =
            component.Style.Position.Value.X
            + component.Style.Size.Value.X
            + component.Style.BorderThickness.Value.Left * 2
            + component.Style.BorderThickness.Value.Right * 2;

        foreach (BaseComponent child in component.children)
        {
            double value = RecurisiveWidthCalc(child);
            if (value > maxValue)
            {
                maxValue = value;
            }
        }
        return maxValue;
    }
}
