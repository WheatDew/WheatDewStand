using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectedItemModelSpawner : MonoBehaviour
{
    [SerializeField]
    private CollectedItemModelUIGroup collectedItemModelUIGroup;
    [System.NonSerialized]
    public CollectedItemModelUIGroup currentCollectedItemModelUIGroup;

    private void Start()
    {
        currentCollectedItemModelUIGroup = Instantiate(collectedItemModelUIGroup);
    }
}
