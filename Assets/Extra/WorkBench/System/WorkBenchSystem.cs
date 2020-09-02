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

    private WorkbenchMenu workbenchMenu;

    protected override void OnStartRunning()
    {
        Entities.ForEach((WorkbenchMenu workbenchMenu) => {
            this.workbenchMenu = workbenchMenu;
        });
    }

    protected override void OnUpdate()
    {
        
    }

    public void GetWorkbenchTaskListJob()
    {
        if(Input.GetMouseButtonDown(1))
        Entities.ForEach((Workbench workbench) =>
        {
            if (workbench.isOver)
            {
                for(int i = 0; i < workbench.TaskName.Length; i++)
                {
                    workbenchMenu.workBenchMenuItemList[i].SetWorkbenchMenuItem(workbench.TaskName[i]);
                    workbenchMenu.workBenchMenuItemList[i].gameObject.SetActive(true);
                }
            }
        });
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
