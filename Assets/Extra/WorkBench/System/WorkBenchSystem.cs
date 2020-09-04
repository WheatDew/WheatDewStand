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

    private WorkbenchMenuController workbenchMenuController;
    private bool isWorkbenchMenuOpen;

    protected override void OnStartRunning()
    {
        Entities.ForEach((WorkbenchMenuController workbenchMenuController) => {
            this.workbenchMenuController = workbenchMenuController;
            workbenchMenuController.transform.GetChild(0).gameObject.SetActive(false);
            foreach (var item in workbenchMenuController.workbenchMenuItemList)
                item.gameObject.SetActive(false);
            isWorkbenchMenuOpen = false;
        });
    }

    protected override void OnUpdate()
    {
        GetWorkbenchTaskListJob();
    }

    public void GetWorkbenchTaskListJob()
    {
        if (isWorkbenchMenuOpen
            &&(Input.GetMouseButtonDown(2)))
        {
            workbenchMenuController.workbenchPosition.gameObject.SetActive(false);
            foreach (var item in workbenchMenuController.workbenchMenuItemList)
                item.gameObject.SetActive(false);
            isWorkbenchMenuOpen = false;
        }

        if(Input.GetMouseButtonDown(1))
        Entities.ForEach((Workbench workbench) =>
        {
            Debug.Log("GetWorkbenchTaskListJob");
            if (workbench.isOver)
            {
                Entities.ForEach((CharacterControllerStatus status, NavMeshAgent agent) => {
                    if (status.isConscriptSelected)
                    {
                        workbenchMenuController.workbenchPosition.position = Input.mousePosition;
                        workbenchMenuController.workbenchPosition.gameObject.SetActive(true);

                        for (int i = 0; i < workbench.TaskName.Length; i++)
                        {
                            workbenchMenuController.workbenchMenuItemList[i].SetWorkbenchMenuItem(workbench.TaskName[i], workbench.WorkPosition,agent);
                            workbenchMenuController.workbenchMenuItemList[i].gameObject.SetActive(true);
                        }
                        isWorkbenchMenuOpen = true;
                    }
                });
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
