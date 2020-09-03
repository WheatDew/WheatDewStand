using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class WorkbenchMenuItem : MonoBehaviour
{
    private UnityAction ua;
    public Text buttonContent;

    public void SetWorkbenchMenuItem(string taskName)
    {
        buttonContent.text = taskName;
    }
}
