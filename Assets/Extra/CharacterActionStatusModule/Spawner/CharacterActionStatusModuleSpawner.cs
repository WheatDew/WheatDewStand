using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class CharacterActionStatusModuleSpawner : MonoBehaviour
{
    public CharacterActionStatusModuleNormalSpawnerExpansion spawnerExpansionPrefab;
    public CharacterActionStatusModuleFileIO fileIOPrefab;

    private void Start()
    {
        CharacterActionStatusModuleNormalSpawnerExpansion spawnerExpansion = Instantiate(spawnerExpansionPrefab, transform);
        CharacterActionStatusModuleFileIO fileIO = Instantiate(fileIOPrefab, transform);
        World.DefaultGameObjectInjectionWorld.GetExistingSystem<SCharacterActionStatus>().fileIO = fileIO;
    }
}
