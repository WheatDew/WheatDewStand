using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class CollectedItemModelUIGroup : MonoBehaviour
{
    public CollectedItemMenuController collectedItemMenuController;

    private void Start()
    {
        //为指定系统添加参数
        World.DefaultGameObjectInjectionWorld.GetExistingSystem<SCollectedItemAndCharacterCollectedAbility>()
            .collectedItemMenuController = collectedItemMenuController;
        World.DefaultGameObjectInjectionWorld.GetExistingSystem<SCharacterBuildingAbility>()
            .collectedItemMenuController = collectedItemMenuController;
    }
}
