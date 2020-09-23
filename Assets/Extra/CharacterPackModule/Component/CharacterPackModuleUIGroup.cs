using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class CharacterPackModuleUIGroup : MonoBehaviour
{
    public CollectedItemMenuController collectedItemMenuController;

    private void Start()
    {
        World.DefaultGameObjectInjectionWorld.GetExistingSystem<SCollectedItemAndCharacterCollectedAbility>()
            .collectedItemMenuController = collectedItemMenuController;
    }
}
