using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using UnityEngine.AI;

public class SWorkbench : ComponentSystem
{
    public RWorkbench workbenchMenuController;
    protected override void OnUpdate()
    {

    }

    public void CraftJob()
    {
        Entities.ForEach((CCharacterActionStatus actionStatus, CCharacterWorkbenchAbility workbenchAbility, CCharacterPack pack) =>
        {
            if (actionStatus.CurrentActionStatus == 2 && workbenchAbility.workbenchTarget != null)
            {
                workbenchAbility.timer += Time.DeltaTime;
                if (workbenchAbility.timer > workbenchAbility.workTime)
                {
                    pack.TaskList.Push(new TCharacterPack { Getting = new string[1] { "果脯" }, Losing = new string[1] { "桃子" } });
                    workbenchAbility.timer = 0;
                }
            }
        });
    }

    public void TargetWorkbench()
    {
        Entities.ForEach((Transform transform, CCharacterWorkbenchAbility CWA, NavMeshAgent NMA, CCharacterActionStatus CAS) =>
        {
            if (CWA.workbenchTarget != null)
            {
                if (Vector3.Distance(transform.position, CWA.workbenchTarget.transform.position) > 0.5f)
                {

                    if (CWA.workbenchTarget.transform.position != CWA.workbenchTarget.transform.position - (CWA.workbenchTarget.transform.position - transform.position).normalized * 1.5f)
                        NMA.destination = CWA.workbenchTarget.transform.position - (CWA.workbenchTarget.transform.position - transform.position).normalized * 0.5f;
                }
                else
                {
                    if (CAS.CurrentActionStatus == 0)
                    {
                        CAS.CurrentActionStatus = 2;

                    }
                }
            }
        });
    }

    public void OpenCollectedItemMenuJob()
    {

        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit raycastInfo;
            Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out raycastInfo);
            bool correctClickedFlag = false;
            Entities.ForEach((CWorkBench workbench) =>
            {

                if (workbench.gameObject == raycastInfo.collider.gameObject)
                {
                    Entities.ForEach((CCharacterNavMeshCommand characterNavMeshCommand,
                        CCharacterWorkbenchAbility CWA, CCharacterBasicModule basic) =>
                    {
                        if (basic.isSelected)
                        {
                            //ToDo: 风险很高的行为,未来需要修改
                            characterNavMeshCommand.CommandList.Push(1);

                            workbenchMenuController.gameObject.SetActive(true);
                            //collectedItemMenuController.CreateItem("工作", CWA, workbench);
                            //collectedItemMenuController.rectTransform.position = Input.mousePosition;
                            correctClickedFlag = true;
                        }
                    });

                }

            });
            if (!correctClickedFlag)
            {
                workbenchMenuController.gameObject.SetActive(false);
                Entities.ForEach((CCharacterNavMeshCommand characterNavMeshCommand,
                    CCharacterCollectedAbility characterCollectedAbility) =>
                {
                    characterNavMeshCommand.CommandList.Push(2);
                    characterCollectedAbility.CollectedItemTarget = null;
                });
            }

        }
        if (Input.GetMouseButtonUp(0))
        {
            workbenchMenuController.gameObject.SetActive(false);
            Entities.ForEach((CCharacterNavMeshCommand characterNavMeshCommand, CCharacterCollectedAbility characterCollectedAbility) =>
            {
                characterNavMeshCommand.CommandList.Push(2);
            });
        }
    }

    public void CheckLeaveCollectedItemJob()
    {
        Entities.ForEach((CCharacterCollectedAbility collectedAbility, CCharacterActionStatus actionStatus) =>
        {
            if (collectedAbility.CollectedItemTarget != null && actionStatus.CurrentActionStatus == 3)
            {
                if (Vector3.Distance(collectedAbility.transform.position, collectedAbility.CollectedItemTarget.transform.position) > 1.5f)
                {
                    collectedAbility.CollectedItemTarget = null;
                }
            }
            if (collectedAbility.CollectedItemTarget == null && actionStatus.CurrentActionStatus == 3)
            {
                actionStatus.CurrentActionStatus = 0;
            }


        });
    }
}
