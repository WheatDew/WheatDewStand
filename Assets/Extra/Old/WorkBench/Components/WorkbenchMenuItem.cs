using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.AI;
using System;

public class WorkbenchMenuItem : MonoBehaviour
{
    private UnityAction<string,Transform,CharacterStatus,NavMeshAgent> ua;
    public Text buttonContent;
    string workTaskName;
    Transform workingPosition;
    CharacterStatus characterStatus;
    NavMeshAgent navMeshAgent;

    public void ClickEvent()
    {
        if (workTaskName != null && workingPosition != null)
        {
            ua?.Invoke(workTaskName, workingPosition,characterStatus,navMeshAgent);
            workTaskName = null;
            workingPosition = null;
            transform.parent.gameObject.SetActive(false);
        }

    }

    internal void SetWorkbenchMenuItem(string workTaskName,Transform workingPosition,CharacterStatus characterStatus,NavMeshAgent navMeshAgent,UnityAction<string,Transform,CharacterStatus,NavMeshAgent> Behaviour)
    {
        buttonContent.text = workTaskName;
        this.workTaskName = workTaskName;
        this.workingPosition = workingPosition;
        this.characterStatus = characterStatus;
        this.navMeshAgent = navMeshAgent;
        ua = Behaviour;
    }
}
