using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ArrayData))]
public class ArrayDataCustomInspector : Editor
{
    SerializedProperty numbersProperty;
    bool foldout;

    public void OnEnable()
    {
        numbersProperty = serializedObject.FindProperty("numbers");
    }

    public override void OnInspectorGUI()
    {
        // EditorGUILayout.LabelField(numbersProperty.displayName);

        foldout = EditorGUILayout.BeginFoldoutHeaderGroup(foldout, numbersProperty.displayName);
        if (foldout)
        {
            for (int i = 0; i < numbersProperty.arraySize; i++)
            {
                EditorGUILayout.BeginHorizontal();
                {
                    EditorGUILayout.PropertyField(numbersProperty.GetArrayElementAtIndex(i), new GUIContent());
                    if (GUILayout.Button("RNG"))
                    {
                        numbersProperty.GetArrayElementAtIndex(i).intValue = Random.Range(0, 100);
                    }
                }
                EditorGUILayout.EndHorizontal();
            }
        }
        EditorGUILayout.EndFoldoutHeaderGroup();

        EditorGUILayout.BeginHorizontal();
        {
            if (GUILayout.Button("+"))
            {
                numbersProperty.arraySize++;
            }

            EditorGUI.BeginDisabledGroup(numbersProperty.arraySize < 1);
            {
                if (GUILayout.Button("-"))
                {
                    if (numbersProperty.arraySize > 0)
                    {
                        numbersProperty.arraySize--;
                    }
                }
            }
            EditorGUI.EndDisabledGroup();
        }
        EditorGUILayout.EndHorizontal();

        serializedObject.ApplyModifiedProperties();
    }
}
