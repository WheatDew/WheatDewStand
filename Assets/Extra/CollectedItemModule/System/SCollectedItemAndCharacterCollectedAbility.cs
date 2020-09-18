using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

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
                    collectedItemMenuController.gameObject.SetActive(true);
                    correctClickedFlag = true;
                }
            });
            if(!correctClickedFlag)
                collectedItemMenuController.gameObject.SetActive(false);
        }

    }
}
