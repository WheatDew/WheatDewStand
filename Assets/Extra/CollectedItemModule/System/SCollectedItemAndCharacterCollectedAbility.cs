using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class SCollectedItemAndCharacterCollectedAbility : ComponentSystem
{
    public CollectedItemMenuController collectedItemMenuController;
    protected override void OnUpdate()
    {
        
    }

    public void OpenCollectedItemMenuJob()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (Input.GetMouseButtonDown(1))
            {
                RaycastHit raycastInfo;
                Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out raycastInfo);

                Entities.ForEach((CCharacterCollectedAbility characterCollectedAbility) => {
                    if (characterCollectedAbility.gameObject == raycastInfo.collider.gameObject)
                    {
                        collectedItemMenuController.gameObject.SetActive(true);
                    }
                });
            }
        }
    }
}
