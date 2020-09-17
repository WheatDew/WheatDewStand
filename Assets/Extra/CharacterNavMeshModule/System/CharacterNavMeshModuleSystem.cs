using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using UnityEngine.AI;

public class CharacterNavMeshModuleSystem : ComponentSystem
{
    protected override void OnUpdate()
    {
        SetCharacterToMousePointPosition();   
    }

    #region 工作
    public void SetCharacterToMousePointPosition()
    {
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit raycastInfo;
            Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out raycastInfo);

            Entities.ForEach((CCharacterBasicModule cChareterBasic, NavMeshAgent navMeshAgent) => {
                navMeshAgent.destination = raycastInfo.point;
            });
        }
    }

    #endregion
}
