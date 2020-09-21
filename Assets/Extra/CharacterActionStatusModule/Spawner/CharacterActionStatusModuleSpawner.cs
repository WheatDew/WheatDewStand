using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class CharacterActionStatusModuleSpawner : MonoBehaviour
{
    public ECharacterActionStatusModuleNormalSpawner spawnerExpansionPrefab;
    public CharacterActionStatusModuleFileIO fileIOPrefab;

    private void Start()
    {
        ECharacterActionStatusModuleNormalSpawner spawnerExpansion = Instantiate(spawnerExpansionPrefab, transform);
        CharacterActionStatusModuleFileIO fileIO = Instantiate(fileIOPrefab, transform);
        World.DefaultGameObjectInjectionWorld.GetExistingSystem<SCharacterActionStatus>().fileIO = fileIO;
    }
}
