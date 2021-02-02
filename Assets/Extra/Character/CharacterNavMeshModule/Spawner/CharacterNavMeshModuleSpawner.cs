using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterNavMeshModuleSpawner : MonoBehaviour
{
    public ECharacterNavMeshModuleNormalSpawner spawnerExpansion;

    private void Start()
    {
        spawnerExpansion = Instantiate(spawnerExpansion, transform);
    }
}
