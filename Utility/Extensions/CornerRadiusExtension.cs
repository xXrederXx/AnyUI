using System;
using System.Numerics;
using System.Windows;
using System.Windows.Media;

namespace AnyUI.Utility.Extensions;

public static class CornerRadiusExtension
{
    public static double MaxRadius(this CornerRadius radius)
    {
        return MyMath.Max(radius.TopLeft, radius.TopRight, radius.BottomLeft, radius.BottomRight);
    }

    public static PathGeometry GenerateClip(this CornerRadius radius, double ActualWidth, double ActualHeight)
    {
        PathGeometry clip = new PathGeometry();

        PathFigure figure = new PathFigure { StartPoint = new Point(radius.TopLeft, 0) };

        // Top edge
        figure.Segments.Add(
            new LineSegment(new Point(ActualWidth - radius.TopRight, 0), true)
        );
        figure.Segments.Add(
            new ArcSegment(
                new Point(ActualWidth, radius.TopRight),
                new Size(radius.TopRight, radius.TopRight),
                0,
                false,
                SweepDirection.Clockwise,
                true
            )
        );

        // Right edge
        figure.Segments.Add(
            new LineSegment(
                new Point(ActualWidth, ActualHeight - radius.BottomRight),
                true
            )
        );
        figure.Segments.Add(
            new ArcSegment(
                new Point(ActualWidth - radius.BottomRight, ActualHeight),
                new Size(radius.BottomRight, radius.BottomRight),
                0,
                false,
                SweepDirection.Clockwise,
                true
            )
        );

        // Bottom edge
        figure.Segments.Add(
            new LineSegment(new Point(radius.BottomLeft, ActualHeight), true)
        );
        figure.Segments.Add(
            new ArcSegment(
                new Point(0, ActualHeight - radius.BottomLeft),
                new Size(radius.BottomLeft, radius.BottomLeft),
                0,
                false,
                SweepDirection.Clockwise,
                true
            )
        );

        // Left edge
        figure.Segments.Add(new LineSegment(new Point(0, radius.TopLeft), true));
        figure.Segments.Add(
            new ArcSegment(
                new Point(radius.TopLeft, 0),
                new Size(radius.TopLeft, radius.TopLeft),
                0,
                false,
                SweepDirection.Clockwise,
                true
            )
        );

        // Close the figure
        figure.IsClosed = true;
        clip.Figures.Add(figure);
        return clip;
    }
}
