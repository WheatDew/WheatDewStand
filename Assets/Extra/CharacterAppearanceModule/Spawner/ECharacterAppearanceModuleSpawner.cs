using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ECharacterAppearanceModuleSpawner : MonoBehaviour
{
    private void Start()
    {
        GameObject characterBasicModulePrefab = FindObjectOfType<CharacterBasicModuleNormalSpawner>().CharacterBasicModulePrefab;
        characterBasicModulePrefab.AddComponent<CCharacterAppearance>();
    }
}
