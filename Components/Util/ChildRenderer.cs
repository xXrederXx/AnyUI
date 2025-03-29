using System.Windows.Controls;
using AnyUI.Utility.Extensions;

namespace AnyUI.Components.Util;

public class ChildRenderer
{
    public readonly List<BaseComponent> Children = [];
    public Canvas Canvas { get; protected set; }

    public ChildRenderer()
    {
        if (Canvas is null)
        {
            Canvas = new Canvas();
        }
    }

    public ChildRenderer(Canvas canvas)
    {
        this.Canvas = canvas;
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
                Canvas.RemoveChild(child);
                child.Reset();
                child.ReRender();
                Canvas.PlaceChild(child);
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
        Canvas.PlaceChild(child);
    }

    public void RemoveChild(BaseComponent child)
    {
        if (Children.Remove(child))
        {
            Canvas.RemoveChild(child);
            child.Parent = null;
        }
        else
        {
            throw new ArgumentException("child is not found or this isnt his parent");
        }
    }
}
