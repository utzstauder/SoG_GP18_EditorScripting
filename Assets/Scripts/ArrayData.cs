using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ArrayData : ScriptableObject
{
    [SerializeField] int[] numbers;

    public ArrayData()
    {
        numbers = new int[3];
    }
}
