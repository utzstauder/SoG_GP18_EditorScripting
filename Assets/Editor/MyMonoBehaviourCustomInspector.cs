using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(MyMonoBehaviour))]
public class MyMonoBehaviourCustomInspector : Editor
{
    MyMonoBehaviour instance;
    SerializedProperty prefabProperty, amountProperty, offsetProperty;


    public void OnEnable()
    {
        instance = (MyMonoBehaviour) target;

        prefabProperty = serializedObject.FindProperty("prefab");
        amountProperty = serializedObject.FindProperty("amount");
        offsetProperty = serializedObject.FindProperty("offset");
    }

    public override void OnInspectorGUI()
    {
        //instance.prefab = EditorGUILayout.ObjectField(instance.prefab, typeof(GameObject)) as GameObject;
        //instance.amount = EditorGUILayout.IntField(instance.amount);
        //instance.offset = EditorGUILayout.Vector3Field("Offset", instance.offset);

        EditorGUILayout.PropertyField(prefabProperty);
        EditorGUILayout.PropertyField(amountProperty);
        EditorGUILayout.PropertyField(offsetProperty);

        if (GUILayout.Button("Instantiate Prefab"))
        {
            instance.InstantiatePrefab();
        }

        serializedObject.ApplyModifiedProperties();
    }
}
