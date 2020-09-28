using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

/// <summary>
/// UI group
/// </summary>
public class GWorkbench : MonoBehaviour
{
    public CollectedItemMenuController collectedItemMenuController;

    private void Start()
    {
        World.DefaultGameObjectInjectionWorld.GetExistingSystem<SCollectedItemAndCharacterCollectedAbility>()
            .collectedItemMenuController = collectedItemMenuController;
    }
}
