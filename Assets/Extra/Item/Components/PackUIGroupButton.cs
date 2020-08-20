using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PackUIGroupButton : MonoBehaviour
{
    public PackUIGroup packUIGroup;
    public string commandValue;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(delegate
        {
            packUIGroup.command = commandValue;
        });
    }
}
