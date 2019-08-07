using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttributeShowcase : MonoBehaviour
{
    [CustomLabel("My Label")]
    public string name = "Hans";

    [CustomLabel("My Object")]
    public GameObject obj;

    [StringDropdown("a", "b", "100", "xxxasdasdas")]
    public string randomStuff;

    [StringDropdown]
    public string s;

    [StringDropdown()]
    public string street;

    [StringDropdown("1", "2")]
    public string singleOption;
}
