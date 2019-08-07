using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MyMonoBehaviour : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    [SerializeField] int amount = 1;
    [SerializeField] Vector3 offset = Vector3.right;

    public void InstantiatePrefab()
    {
        for (int i = 0; i < amount; i++)
        {
#if UNITY_EDITOR
            GameObject newObject = PrefabUtility.InstantiatePrefab(prefab, transform) as GameObject;
            newObject.transform.localPosition += offset * i;

            Undo.RegisterCreatedObjectUndo(newObject, "Instantiate Prefab");
#else
            GameObject newObject = Instantiate(prefab, transform);
            newObject.transform.localPosition += offset * i;
#endif
        }
    }
}
