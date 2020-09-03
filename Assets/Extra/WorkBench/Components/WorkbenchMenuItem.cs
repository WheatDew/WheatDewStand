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
    private Transform targetPoint;
    private NavMeshAgent navMeshAgent;


    public void SetWorkbenchMenuItem(string taskName,Transform target,NavMeshAgent agent)
    {
        targetPoint = target;
        navMeshAgent = agent;
        buttonContent.text = taskName;
    }

    public void ClickEvent()
    {
        if (targetPoint != null)
        {
            navMeshAgent.destination = targetPoint.position;
            targetPoint = null;
            transform.parent.gameObject.SetActive(false);
        }
    }
}
