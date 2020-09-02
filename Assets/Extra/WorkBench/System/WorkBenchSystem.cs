using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using UnityEngine.AI;

//[UpdateAfter(typeof(CharacterControllerStatusSystem))]
public class WorkbenchSystem : ComponentSystem
{
    private bool isGoingWorkbench;
    private NavMeshAgent navMeshAgent;

    protected override void OnUpdate()
    {
        
    }

    public void GetWorkbenchTaskListJob()
    {
        
    }

    public void SetGoingWorkbenchCharacterJob()
    {
        WorkbenchTaskData.CreateInstance();
        Debug.Log(WorkbenchTaskData.GetTaskData("简单").TimeCost);
        if (Input.GetMouseButtonDown(1))
            Entities.ForEach((CharacterControllerStatus status, NavMeshAgent agent) => {
                if (status.isConscriptSelected)
                {
                    navMeshAgent = agent;
                    isGoingWorkbench = true;
                }
            });
    }

    public void CharacterGoingWorkbenchJob()
    {
        if (isGoingWorkbench && navMeshAgent!=null)
            Entities.ForEach((Workbench workbench) =>
            {
                if (workbench.isOver)
                {
                    navMeshAgent.destination =workbench.WorkPosition.position;
                    isGoingWorkbench = false;
                }
            });
    }
}
