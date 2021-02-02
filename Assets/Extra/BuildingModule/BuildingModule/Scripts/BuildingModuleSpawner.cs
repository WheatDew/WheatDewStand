using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingModuleSpawner : MonoBehaviour
{
    [SerializeField]
    private BasicBuiding basicBuidingPrefab;

    static HashSet<BasicBuiding> buidingList = new HashSet<BasicBuiding>(buidingList);

    public void AddBuiding()
    {
        BasicBuiding basicBuiding = Instantiate(basicBuidingPrefab);
        buidingList.Add(basicBuiding);
    }
}
