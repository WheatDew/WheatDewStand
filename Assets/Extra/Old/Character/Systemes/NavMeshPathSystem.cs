using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class NavMeshPathSystem : ComponentSystem
{
    protected override void OnUpdate()
    {
        MousePointMoveJob();
    }

    private void MousePointMoveJob()
    {
        if (Input.GetMouseButtonDown(1))
            Entities.ForEach((CharacterControllerStatus status, UnityEngine.AI.NavMeshAgent agent) =>
            {
                if (status.isConscriptSelected)
                {
                    RaycastHit hit;
                    if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
                    {
                        if(hit.collider.tag=="Ground")
                        agent.destination = hit.point;
                    }

                }
            });
    }

}
