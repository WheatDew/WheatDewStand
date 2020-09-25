using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPackModuleSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject CharacterPackModuleUIGroupPrefab;
    [SerializeField]
    private GameObject CharacterPackModuleSpawnerExpansionPrefab;

    private void Start()
    {
        GameObject characterPackModuleUIGroup = Instantiate(CharacterPackModuleUIGroupPrefab,FindObjectOfType<Canvas>().transform);
        GameObject characterPackModuleSpawnerExpansion = Instantiate(CharacterPackModuleSpawnerExpansionPrefab, transform);
    }
}
