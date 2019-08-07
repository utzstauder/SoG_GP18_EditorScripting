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
            //EditorGUI.HelpBox(position, "Use [StringDropdown] with string fields.", MessageType.Info);
            EditorGUI.PropertyField(position, property, label);
            return;
        }

        StringDropdownAttribute stringDropdown = (StringDropdownAttribute)attribute;

        if (stringDropdown.labels == null)
        {
            //EditorGUI.HelpBox(position, "Please supply more than one option to use [StringDropdown].", MessageType.Info);
            EditorGUI.PropertyField(position, property, label);
            return;
        } else
        {
            if (stringDropdown.labels.Length < 2)
            {
                //EditorGUI.HelpBox(position, "Please supply more than one option to use [StringDropdown].", MessageType.Info);
                EditorGUI.PropertyField(position, property, label);
                return;
            }
        }

        EditorGUI.BeginProperty(position, label, property);
        {
            position = EditorGUI.PrefixLabel(position, label);

            labels = new string[stringDropdown.labels.Length];
            stringDropdown.labels.CopyTo(labels, 0);
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
        EditorGUI.EndProperty();
    }
}
