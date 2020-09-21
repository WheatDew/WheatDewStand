using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ECharacterNavMeshModuleNormalSpawner : MonoBehaviour
{
    private void Start()
    {
        GameObject CharacterBasicModulePrefab = FindObjectOfType<CharacterBasicModuleNormalSpawner>().CharacterBasicModulePrefab;
        CharacterBasicModulePrefab.AddComponent<CCharacterNavMesh>();
        CharacterBasicModulePrefab.AddComponent<CCharacterNavMeshCommand>();
        NavMeshAgent navMeshAgent= CharacterBasicModulePrefab.AddComponent<NavMeshAgent>();
        navMeshAgent.baseOffset = 0;
        navMeshAgent.angularSpeed = 0;
    }
}
