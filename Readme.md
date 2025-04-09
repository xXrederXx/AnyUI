# Custom WPF UI Library
---
## Overview
This is a custom UI library built in C# using WPF. It provides a set of reusable and customizable UI components to enhance WPF applications without relying on XML-based design.

## Features
- Pure C# implementation (no XAML)
- Customizable UI components
- Lightweight and easy to integrate
- Flexible styling system

## Installation
I will provide a DLL file. Once available, you can reference it in your project:

1. Download the DLL file from the releases section.
2. Add the reference to your project in Visual Studio:
   - Right-click on your project in **Solution Explorer**.
   - Click **Add Reference...**
   - Browse and select the downloaded DLL file.

## Usage
```csharp
using AnyUI.Components;
using AnyUI.Components.Util;
using AnyUI.Styling;

class Program
{
    [STAThread] // Required for WPF
    static void Main(string[] args)
    {
        AnyWindow anyWindow = new AnyWindow();
        Style style = new Style();
        style.Size.Value = new(300);
        style.Position.Value = new(100);
        style.BorderThickness.Value = new(10);

        BaseComponent outer = new BaseComponent()
        {
            Style = style,
        };
        
        anyWindow.AddChild(outer);
        anyWindow.Run();
    }
}
```

## License
This project is licensed under the **IDK what license** license.

**You are free to:**
- Share and adapt the library for personal and commercial projects.

**Restrictions:**
- You may not sell this library as your own product.
- No attribution is required.

## Comit Structure
Not open for commits, but my abbreviations are:
-   feat: Feature
-   fix: fix for a bug
-   upt: update Something
-   rft: refactoring
