using UnityEngine;

public class CustomLabelAttribute : PropertyAttribute
{
    public string label;

    public CustomLabelAttribute(string label)
    {
        this.label = label;
    }
}
