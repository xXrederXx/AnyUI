using System.Windows;
using System.Windows.Controls;
using AnyUI.Components.Util;
using AnyUI.Utility.UI;

namespace AnyUI.Components;

public class AnyWindow : BaseComponent
{
#pragma warning disable CS8618 // if it would be null after leafing cunstructor, the constructor threw an exception
    private static Application app;
#pragma warning restore CS8618
    private readonly Window window;
    private readonly ScrollViewer scroll = new();

    public AnyWindow()
    {
        if (app != null)
        {
            throw new Exception("You already opened a Window. To open another use the class xyz");
        }
        window = new Window();
        app = new Application();
        scroll.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;
        scroll.HorizontalScrollBarVisibility = ScrollBarVisibility.Auto;
        scroll.Content = canvas;
        window.Content = scroll;
        canvas.Background = Style.BackgroundColor;
        uidPrefix = "Win";
        LastGenerated = canvas;
        BaseComponent parent = new();
        parent.Children.Add(this);
        this.Parent = parent;
    }

    public void Run()
    {
        canvas.MinHeight = CalculateDimensions.CalculateHeight(this);
        canvas.MinWidth = CalculateDimensions.CalculateWidth(this);
        app.Run(window);
    }
    public override UIElement GenerateUIElement()
    {
        canvas.Background = Style.BackgroundColor;
        canvas.Uid = uidPrefix + canvas.GetHashCode();
        return scroll;
    }
}
