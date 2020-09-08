using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using UnityEngine.AI;
using UnityEngine.Events;

//[UpdateAfter(typeof(CharacterControllerStatusSystem))]
public class WorkbenchSystem : ComponentSystem
{

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
            if (workbench.isOver)
            {
                Entities.ForEach((CharacterControllerStatus status, NavMeshAgent agent,CharacterStatus characterStatus,CharacterWorkbenchInfo workbenchInfo) => {
                    if (status.isConscriptSelected)
                    {
                        workbenchMenuController.workbenchPosition.position = Input.mousePosition;
                        workbenchMenuController.workbenchPosition.gameObject.SetActive(true);

                        for (int i = 0; i < workbench.TaskName.Length; i++)
                        {
                            UnityAction<string,Transform> unityAction = delegate {
                                characterStatus.Action = WorkbenchTaskData.GetTaskData(string.Copy(workbench.TaskName[i])).ActionName;
                                agent.destination = workbench.WorkPosition.position;
                            };

                            workbenchInfo.WorkingName = workbench.TaskName[i];
                            workbenchInfo.WorkingPosition = workbench.WorkPosition;
                            workbenchMenuController.workbenchMenuItemList[i].SetWorkbenchMenuItem(workbench.TaskName[i], unityAction);
                            workbenchMenuController.workbenchMenuItemList[i].gameObject.SetActive(true);
                        }
                        isWorkbenchMenuOpen = true;
                    }
                });
            }
        });
    }

    public void WorkbenchSetWorkingJob()
    {
        Entities.ForEach((CharacterStatus status,CharacterWorkbenchInfo workbenchInfo,CharacterPack characterPack,Transform transform) =>
        {
            if (transform.position == workbenchInfo.WorkingPosition.position)
            {
                workbenchInfo.Timer += Time.DeltaTime;
                if (workbenchInfo.Timer > workbenchInfo.TaskTimeCost)
                {
                    characterPack.ItemChangeTaskList.Push(new ItemTask { 
                        Getting=WorkbenchTaskData.GetTaskData(workbenchInfo.WorkingName).GettingList,
                        Losing=WorkbenchTaskData.GetTaskData(workbenchInfo.WorkingName).LosingList
                    });
                }
            }
        });
    }

}
