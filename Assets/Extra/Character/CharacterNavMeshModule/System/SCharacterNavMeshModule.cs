using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using UnityEngine.AI;

[UpdateAfter(typeof(SCharacterBasicModule))]
public class SCharacterNavMeshModule : ComponentSystem
{
    protected override void OnUpdate()
    {
        CommandJob();
        SetCharacterToMousePointPositionJob();   
    }

    #region 工作
    public void SetCharacterToMousePointPositionJob()
    {
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit raycastInfo;
            Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out raycastInfo);

            Entities.ForEach((CCharacterBasicModule characterBasic, NavMeshAgent navMeshAgent,CCharacterNavMesh characterNavMesh) => {
                if(!characterNavMesh.KeepStanding&&characterBasic.isSelected)
                navMeshAgent.destination = raycastInfo.point;
            });
        }
    }

    public void CommandJob()
    {
        Entities.ForEach((CCharacterNavMeshCommand characterNavMeshCommand, CCharacterNavMesh characterNavMesh) =>
        {
            if(characterNavMeshCommand.CommandList.Count!=0)
            switch (characterNavMeshCommand.CommandList.Pop())
            {
                case 1:
                    SetKeepStanding(characterNavMesh);
                    break;
                case 2:
                    ResetKeepStanding(characterNavMesh);
                    break;
            }
        });
    }

    #endregion

    #region 方法

    public void SetKeepStanding(CCharacterNavMesh characterNavMesh)
    {
        characterNavMesh.KeepStanding = true;
    }

    public void ResetKeepStanding(CCharacterNavMesh characterNavMesh)
    {
        characterNavMesh.KeepStanding = false;
    }

    #endregion
}
