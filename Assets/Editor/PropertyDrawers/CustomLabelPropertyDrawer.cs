using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(CustomLabelAttribute))]
public class CustomLabelPropertyDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        CustomLabelAttribute customLabel = (CustomLabelAttribute) attribute;
        
        label.text = customLabel.label;
        EditorGUI.PropertyField(position, property, label);
    }
}
