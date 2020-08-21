using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackPage : MonoBehaviour
{
    public bool IsOpen;
    public GameObject Display;
    public PackPageItem[] ItemList;
    public List<string> ItemAdd = new List<string>();
    public List<string> ItemRemve = new List<string>();
}
