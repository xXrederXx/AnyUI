using AnyUI.Components.Util;

namespace AnyUI.Utility.UI;

public static class CalculateDimensions
{
    public static double CalculateHeight(ChildRenderer TopNode)
    {
        double maxValue = double.MinValue;
        foreach (BaseComponent child in TopNode.Children)
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
            component.Style.Position.Get().Y
            + component.Style.Size.Get().Y
            + component.Style.BorderThickness.Get().Top * 2
            + component.Style.BorderThickness.Get().Bottom * 2;

        foreach (BaseComponent child in component.Children)
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
        foreach (BaseComponent child in TopNode.Children)
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
            component.Style.Position.Get().X
            + component.Style.Size.Get().X
            + component.Style.BorderThickness.Get().Left * 2
            + component.Style.BorderThickness.Get().Right * 2;

        foreach (BaseComponent child in component.Children)
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
