using System;
using UnityEditor;
using UnityEngine;

[InitializeOnLoad]
public class HierarchyWindowLayerInfo
{
    static HierarchyWindowLayerInfo()
    {
        EditorApplication.hierarchyWindowItemOnGUI += HierarchyItemOnGUI;
    }

    private static void HierarchyItemOnGUI(int instanceID, Rect selectionRect)
    {
        var gameObject = EditorUtility.InstanceIDToObject(instanceID) as GameObject;

        if (gameObject == null) return;
        if (gameObject.transform.childCount < 1) return;

        EditorGUI.LabelField(
            selectionRect,
            "" + gameObject.transform.childCount,
            new GUIStyle() { alignment = TextAnchor.MiddleRight }
            );
    }
}
