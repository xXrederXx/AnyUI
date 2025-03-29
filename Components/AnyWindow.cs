using System.Windows;
using System.Windows.Controls;
using AnyUI.Components.Util;
using AnyUI.Utility.UI;

namespace AnyUI.Components;

public class AnyWindow : BaseComponent
{
#pragma warning disable CS8618 // If it would leave with null the app threw an error
    private static Application app;
    private readonly Window window;
    private readonly ScrollViewer scroll = new();
    public static AnyWindow? instance { get; private set; }
#pragma warning restore CS8618 

    public AnyWindow()
    {
        if (instance != null)
        {
            throw new Exception("You already opened a Window. To open another use the class xyz");
        }
        instance = this;

        window = new Window();
        app = new Application();

        scroll.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;
        scroll.HorizontalScrollBarVisibility = ScrollBarVisibility.Auto;
        scroll.Content = Canvas;

        window.Content = scroll;

        Canvas.Background = Style.BackgroundColor;

        uidPrefix = "Win";

        LastGenerated = Canvas;

        BaseComponent parent = new();
        parent.Children.Add(this);
        this.Parent = parent;

        Style = new Styling.Style(Size: new(700, 500));
    }

    public void Run()
    {
        GenerateUIElement();
        app.Run(window);
    }
    public override UIElement GenerateUIElement()
    {
        WPFHelper.ApplyBaseStyle(window, Style);
        Canvas.Background = Style.BackgroundColor;
        Canvas.Uid = uidPrefix + Canvas.GetHashCode();
        Canvas.MinHeight = Math.Max(CalculateDimensions.CalculateHeight(this), 10);
        Canvas.MinWidth = Math.Max(CalculateDimensions.CalculateWidth(this), 10);
        return scroll;
    }
}
