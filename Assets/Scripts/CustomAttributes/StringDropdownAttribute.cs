using UnityEngine;

public class StringDropdownAttribute : PropertyAttribute
{
    public string[] labels;

    public StringDropdownAttribute()
    {
        labels = new string[0];
    }

    public StringDropdownAttribute(string label)
    {
        labels = new string[1] { label };
    }

    public StringDropdownAttribute(params string[] labels)
    {
        this.labels = labels;
    }
}
