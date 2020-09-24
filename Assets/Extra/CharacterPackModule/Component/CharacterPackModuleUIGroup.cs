using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class CharacterPackModuleUIGroup : MonoBehaviour
{
    public CharacterPackMenuController characterPackMenuController;

    private void Start()
    {
        World.DefaultGameObjectInjectionWorld.GetExistingSystem<SCharacterPack>()
            .characterPackController = characterPackMenuController;
    }
}
