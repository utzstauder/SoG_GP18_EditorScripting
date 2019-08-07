using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(StringDropdownAttribute))]
public class StringDropdownPropertyDrawer : PropertyDrawer
{
    string[] labels;
    int[] labelIndices;
    int selectedLabelIndex;
    string selectedLabel;

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        if (property.propertyType != SerializedPropertyType.String)
        {
            EditorGUILayout.HelpBox("Use [StringDropdown] with string fields.", MessageType.Info);
            EditorGUI.PropertyField(position, property, label);
            return;
        }

        position = EditorGUI.PrefixLabel(position, label);

        labels = new string[3] { "one", "two", "three" };
        labelIndices = new int[labels.Length];
        selectedLabelIndex = 0;
        selectedLabel = property.stringValue;

        for (int i = 0; i < labels.Length; i++)
        {
            labelIndices[i] = i;

            if (labels[i] == selectedLabel)
            {
                selectedLabelIndex = i;
            }
        }

        selectedLabelIndex = EditorGUI.IntPopup(position, selectedLabelIndex, labels, labelIndices);
        property.stringValue = labels[selectedLabelIndex];
    }
}
