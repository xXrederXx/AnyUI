using System.Windows.Controls;
using AnyUI.Utility.Extensions;

namespace AnyUI.Components.Util;

public class ChildRenderer
{
    public readonly List<BaseComponent> children = [];
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
        if (children.Count == 0)
        {
            System.Console.WriteLine("Leaf Node");
            return;
        }
        foreach (BaseComponent child in children)
        {
            if (child as AnyWindow is not null)
            {
                System.Console.WriteLine("CHILD WINDOW");
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
