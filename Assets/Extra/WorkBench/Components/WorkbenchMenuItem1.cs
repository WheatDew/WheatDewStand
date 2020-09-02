using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class WorkbenchMenuItem : MonoBehaviour
{
    private UnityAction ua;
    private Text buttonContent;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(ua);
        buttonContent = transform.GetChild(0).GetComponent<Text>();
    }

    public void SetWorkbenchMenuItem()
    {

    }
}
