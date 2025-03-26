using System.Windows;
using System.Windows.Media;

namespace AnyUI.Utility.Types;

public record class Font
{
    public FontFamily Family;
    public double Size;
    public FontStyle Style;
    public FontWeight Weight;
    public FontStretch Stretch;

    public Font(
        FontFamily Family,
        double Size,
        FontStyle Style,
        FontWeight Weight,
        FontStretch Stretch
    )
    {
        this.Family = Family;
        this.Size = Size;
        this.Style = Style;
        this.Weight = Weight;
        this.Stretch = Stretch;
    }
}
