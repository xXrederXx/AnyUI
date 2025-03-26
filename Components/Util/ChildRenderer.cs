using System.Windows.Controls;
using AnyUI.Utility.Extensions;

namespace AnyUI.Components.Util;

public class ChildRenderer
{
    public readonly List<BaseComponent> Children = [];
    protected Canvas canvas;

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
        if (Children.Count == 0)
        {
            return;
        }

        foreach (BaseComponent child in Children)
        {
            if (child as AnyWindow is not null) // This will be executed if the child is a Window, so it dosnt break
            {
                child.ReRender();
                child.GenerateUIElement();
                continue;
            }
            else
            {
                canvas.RemoveChild(child);
                child.Reset();
                child.ReRender();
                canvas.PlaceChild(child);
            }
        }
    }

    public void AddChild(BaseComponent child)
    {
        if (child.Parent != null)
        {
            throw new ArgumentException("child cant have a parent");
        }
        child.Parent = this as BaseComponent;
        Children.Add(child);
        canvas.PlaceChild(child);
    }

    public void RemoveChild(BaseComponent child)
    {
        if (Children.Remove(child))
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
