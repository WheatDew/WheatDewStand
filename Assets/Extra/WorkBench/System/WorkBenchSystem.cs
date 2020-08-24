using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using UnityEngine.AI;

//[UpdateAfter(typeof(CharacterControllerStatusSystem))]
public class WorkBenchSystem : ComponentSystem
{
    protected override void OnUpdate()
    {
        Entities.ForEach((CharacterControllerStatus status, NavMeshAgent agent) => {
            if (status.isConscriptSelected&&Input.GetMouseButtonDown(1))
            {
                RaycastHit hit;
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100)
                && hit.collider.gameObject.tag.Equals("WorkBench"))
                    agent.destination = hit.collider.GetComponent<WorkBench>().WorkPosition;
            }
        });

        

    }

    
}
