
namespace AnyUI.Styling;

public class StyleVar<T>
{
    private T? value;
    public T Value
    {
        get
        {
            if (value is null || value.GetHashCode() == default(T)?.GetHashCode())
            {
                return GetDefaultValue;
            }
            else
            {
                return value;
            }
        }
        set { this.value = value; }
    }
    public readonly bool Inherit;

    private readonly T defaultValue;
    private T? parentValue;
    private T GetDefaultValue => Inherit && parentValue is not null ? parentValue : defaultValue;

    public StyleVar(bool inherit, T defaultValue)
    {
        this.Inherit = inherit;
        this.defaultValue = defaultValue;
        value = default;
    }

    public void UpdateStyleVar(StyleVar<T> parentStyleVar)
    {
        parentValue = parentStyleVar.Value;
    }
}
