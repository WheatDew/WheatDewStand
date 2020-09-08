using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.AI;
using System;

public class WorkbenchMenuItem : MonoBehaviour
{
    private UnityAction<string,Transform> ua;
    public Text buttonContent;
    string workTaskName;
    Transform workingPosition;


    public void ClickEvent()
    {
        if (workTaskName != null && workingPosition != null)
        {
            ua?.Invoke(workTaskName, workingPosition);
            workTaskName = null;
            workingPosition = null;
        }

    }

    internal void SetWorkbenchMenuItem(string ButtonText,UnityAction<string,Transform> Behaviour)
    {
        buttonContent.text = ButtonText;
        ua = Behaviour;
    }
}
