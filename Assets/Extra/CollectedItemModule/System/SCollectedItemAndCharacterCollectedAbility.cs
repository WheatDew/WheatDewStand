using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

[UpdateBefore(typeof(SCharacterBasicModule))]
public class SCollectedItemAndCharacterCollectedAbility : ComponentSystem
{
    public CollectedItemMenuController collectedItemMenuController;
    protected override void OnUpdate()
    {
        OpenCollectedItemMenuJob();
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
                    Entities.ForEach((CCharacterNavMeshCommand characterNavMeshCommand) =>
                    {
                        //ToDo: 风险很高的行为,未来需要修改
                        characterNavMeshCommand.CommandList.Push(1);
                    });
                    collectedItemMenuController.gameObject.SetActive(true);
                    collectedItemMenuController.rectTransform.position = Input.mousePosition;
                    correctClickedFlag = true;
                }
            });
            if (!correctClickedFlag)
            {
                collectedItemMenuController.gameObject.SetActive(false);
                Entities.ForEach((CCharacterNavMeshCommand characterNavMeshCommand) =>
                {
                    characterNavMeshCommand.CommandList.Push(2);
                });
            }

        }
        if (Input.GetMouseButtonUp(0))
        {
            collectedItemMenuController.gameObject.SetActive(false);
            Entities.ForEach((CCharacterNavMeshCommand characterNavMeshCommand) =>
            {
                characterNavMeshCommand.CommandList.Push(2);
            });
        }


    }
}

public enum Collection { Collecting,Collected,Stop};
