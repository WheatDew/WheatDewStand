using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class CollectedItemModelUIGroup : MonoBehaviour
{
    public RWorkbench workbenchMenuController;

    private void Start()
    {
        World.DefaultGameObjectInjectionWorld.GetExistingSystem<SWorkbench>()
            .workbenchMenuController = workbenchMenuController;
    }
}
