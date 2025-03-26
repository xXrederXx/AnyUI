using System.Windows.Controls;
using AnyUI.Utility.Extensions;

namespace AnyUI.Components.Util;

public class ChildRenderer
{
    public readonly List<BaseComponent> children = [];
    protected readonly Canvas canvas;

    public ChildRenderer()
    {
        if (canvas is null)
        {
            canvas = new Canvas();
        }
    }

    public ChildRenderer(Canvas canvas)
    {
        this.canvas = canvas;
    }

    public void ReRender()
    {
        canvas.Children.Clear();
        foreach(var child in children)
        {
            canvas.PlaceChild(child);
            child.ReRender();
        }
    }
    public void AddChild(BaseComponent child)
    {
        if (child.Parent != null)
        {
            throw new ArgumentException("child cant have a parent");
        }
        child.Parent = this as BaseComponent;
        children.Add(child);
        canvas.PlaceChild(child);
    }

    public void RemoveChild(BaseComponent child)
    {
        if (children.Remove(child))
        {
            canvas.RemoveChild(child);
            child.Parent = null;
        }
        else
        {
            throw new ArgumentException("child is not found or this isnt his parent");
        }
    }
}
