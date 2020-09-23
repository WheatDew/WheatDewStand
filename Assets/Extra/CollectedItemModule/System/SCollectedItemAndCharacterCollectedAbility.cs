using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using UnityEngine.AI;

[UpdateBefore(typeof(SCharacterBasicModule))]
public class SCollectedItemAndCharacterCollectedAbility : ComponentSystem
{
    public CollectedItemMenuController collectedItemMenuController;
    protected override void OnUpdate()
    {
        TargetCollectedItem();
        OpenCollectedItemMenuJob();
    }

    public void CollectingItemJob()
    {
        Entities.ForEach((CCharacterActionStatus actionStatus,CCharacterCollectedAbility collectedAbility,CCharacterPack pack) =>
        {
            if(actionStatus.CurrentActionStatus==3&&collectedAbility.CollectedItemTarget!=null)
            {
                collectedAbility.timer += Time.DeltaTime;
                if (collectedAbility.timer > collectedAbility.workTime)
                {
                    pack.TaskList.Push(new TCharacterPack { Getting = new string[1] { "桃子" }, Losing = new string[0] { } });
                }
            }
        });
    }

    public void TargetCollectedItem()
    {
        Entities.ForEach((Transform transform, CCharacterCollectedAbility CCA,NavMeshAgent NMA,CCharacterActionStatus CAS) =>
        {
            if (CCA.CollectedItemTarget != null)
            {

                if (Vector3.Distance(transform.position, CCA.CollectedItemTarget.transform.position) > 0.5f)
                {

                    if (CCA.CollectedItemTarget.transform.position != CCA.CollectedItemTarget.transform.position - (CCA.CollectedItemTarget.transform.position - transform.position).normalized * 1.5f)
                        NMA.destination = CCA.CollectedItemTarget.transform.position- (CCA.CollectedItemTarget.transform.position - transform.position).normalized * 0.5f;
                }
                else
                {
                    if (CAS.CurrentActionStatus == 0)
                    {
                        CAS.CurrentActionStatus = 3;

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
            Entities.ForEach((CCollectedItem collectedItem) =>
            {
                if (collectedItem.gameObject == raycastInfo.collider.gameObject)
                {
                    Entities.ForEach((CCharacterNavMeshCommand characterNavMeshCommand, 
                        CCharacterCollectedAbility characterCollectedAbility) =>
                    {
                        //ToDo: 风险很高的行为,未来需要修改
                        characterNavMeshCommand.CommandList.Push(1);

                        collectedItemMenuController.gameObject.SetActive(true);
                        collectedItemMenuController.CreateItem("采集", characterCollectedAbility, collectedItem);
                    collectedItemMenuController.rectTransform.position = Input.mousePosition;
                        correctClickedFlag = true;
                    });
                }

            });
            if (!correctClickedFlag)
            {
                collectedItemMenuController.gameObject.SetActive(false);
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
            collectedItemMenuController.gameObject.SetActive(false);
            Entities.ForEach((CCharacterNavMeshCommand characterNavMeshCommand, CCharacterCollectedAbility characterCollectedAbility) =>
            {
                characterNavMeshCommand.CommandList.Push(2);
            });
        }
    }
}

public enum Collection { Collecting,Collected,Stop};
