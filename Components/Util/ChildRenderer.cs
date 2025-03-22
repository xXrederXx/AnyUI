using System;
using System.Windows.Controls;
using AnyUI.Utility.Extensions;

namespace AnyUI.Components.Util;

public class ChildRenderer
{
    private List<BaseComponent> children = [];
    protected readonly Canvas _canvas;

    public ChildRenderer()
    {
        if (this._canvas is null)
        {
            _canvas = new Canvas();
        }
    }

    public ChildRenderer(Canvas canvas)
    {
        this._canvas = canvas;
    }

    public void AddChild(BaseComponent child)
    {
        if (child.Parent != null)
        {
            throw new ArgumentException("child cant have a parent");
        }
        children.Add(child);
        _canvas.PlaceChild(child);
    }

    public void RemoveChild(BaseComponent child)
    {
        if (children.Remove(child))
        {
            child.Parent = null;
        }
        else
        {
            throw new ArgumentException("child is not found or this isnt his parent");
        }
    }
}
