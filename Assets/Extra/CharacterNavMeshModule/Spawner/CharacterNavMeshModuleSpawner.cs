using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterNavMeshModuleSpawner : MonoBehaviour
{
    public CharacterNavMeshModuleNormalSpawnerExpansion spawnerExpansion;

    private void Start()
    {
        spawnerExpansion = Instantiate(spawnerExpansion, transform);
    }
}
