using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PackPageItem : MonoBehaviour
{
    public Text Name,Count;

    public void SetValue(string Name,int Count)
    {
        this.Name.text = Name;
        this.Count.text = Count.ToString();
    }
}
