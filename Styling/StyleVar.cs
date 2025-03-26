namespace AnyUI.Styling;

public class StyleVar<T>
{
    private T? value;
    public T Value
    {
        get
        {
            if (HasCustomValue && value != null)
            {
                return value;
            }
            else
            {
                return GetDefaultValue;
            }
        }
        set
        {
            this.value = value;
            HasCustomValue = true;
            OnChanged?.Invoke();
        }
    }
    public readonly bool Inherit;
    public Action? OnChanged;

    private T? parentValue;
    private readonly T defaultValue;
    private T GetDefaultValue => Inherit && parentValue is not null ? parentValue : defaultValue;
    private bool HasCustomValue = false;

    public StyleVar(bool inherit, T defaultValue)
    {
        Inherit = inherit;
        this.defaultValue = defaultValue;
        value = default;
    }

    public void UpdateStyleVar(StyleVar<T> parentStyleVar)
    {
        parentValue = parentStyleVar.Value;
    }

    public static implicit operator T(StyleVar<T> styleVar) => styleVar.Value;
}
