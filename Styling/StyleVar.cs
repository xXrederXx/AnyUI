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
    private bool HasCustomValue = false;
    public readonly bool Inherit;

    private readonly T defaultValue;
    private T? parentValue;
    private T GetDefaultValue => Inherit && parentValue is not null ? parentValue : defaultValue;
    public Action? OnChanged;

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
