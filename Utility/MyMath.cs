using System;

namespace AnyUI.Utility;

public class MyMath
{
    public static double Max(params double[] values)
    {
        double max = double.MinValue;
        foreach (var value in values)
        {
            max = Math.Max(max, value);
        }
        return max;
    }
}
