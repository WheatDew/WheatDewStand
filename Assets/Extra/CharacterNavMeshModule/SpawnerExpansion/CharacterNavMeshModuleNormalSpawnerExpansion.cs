using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterNavMeshModuleNormalSpawnerExpansion : MonoBehaviour
{
    private void Start()
    {
        GameObject CharacterBasicModulePrefab = FindObjectOfType<CharacterBasicModuleNormalSpawner>().CharacterBasicModulePrefab;
        NavMeshAgent navMeshAgent= CharacterBasicModulePrefab.AddComponent<NavMeshAgent>();
        navMeshAgent.baseOffset = 0;
        navMeshAgent.angularSpeed = 0;
    }
}
