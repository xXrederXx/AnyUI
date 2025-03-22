using System.Windows;
using System.Windows.Media;
using AnyUI.Components.Util;

namespace AnyUI.Components;

public class AnyWindow : ChildRenderer
{
#pragma warning disable CS8618 // if it would be null after leafing cunstructor, the constructor threw an exception
    private static Application app;
#pragma warning restore CS8618
    private Window window;

    public AnyWindow()
    {
        if (app != null)
        {
            throw new Exception("You already opened a Window. To open another use the class xyz");
        }
        window = new Window();
        app = new Application();
        window.Content = _canvas;
        _canvas.Background = new SolidColorBrush(Color.FromArgb(255, 255, 0, 1));
    }

    public void Run()
    {
        app.Run(window);
    }
}
