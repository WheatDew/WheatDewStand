using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;
using UnityEngine.UI;

public class PackPageItem : MonoBehaviour
{
    public PackPage packPage;
    public Text Name,Count;
    private string ItemName;
    private int ItemCount;

    public void SetValue(string Name,int Count)
    {
        this.Name.text = Name;
        this.Count.text = Count.ToString();
        ItemName = Name;
        ItemCount = Count;
    }

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(delegate {
            //TODO按钮事件
        });
    }
}
