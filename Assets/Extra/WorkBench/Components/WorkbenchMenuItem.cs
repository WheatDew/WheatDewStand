using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.AI;

public class WorkbenchMenuItem : MonoBehaviour
{
    private UnityAction ua;
    public Text buttonContent;

    public void SetWorkbenchMenuItem(string taskName,UnityAction task)
    {
        buttonContent.text = taskName;
        ua = task;
    }

    public void ClickEvent()
    {
        ua?.Invoke();
    }
}
