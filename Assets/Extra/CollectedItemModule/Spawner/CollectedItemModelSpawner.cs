using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectedItemModelSpawner : MonoBehaviour
{
    [SerializeField]
    private CollectedItemModelUIGroup collectedItemModelUIGroup;
    [SerializeField]
    private ECollectedItemModel collectedItemModelSpawnerExpansion;
    [System.NonSerialized]
    public CollectedItemModelUIGroup currentCollectedItemModelUIGroup;
    [SerializeField]
    private GameObject CollectedItemPrefab;

    private void Start()
    {
        currentCollectedItemModelUIGroup = Instantiate(collectedItemModelUIGroup);
        ECollectedItemModel tempSpawnerExpansion = Instantiate(collectedItemModelSpawnerExpansion);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.G))
            CreateCollectedItem(new Vector3(4,0,4));
    }

    public void CreateCollectedItem(Vector3 position)
    {
        GameObject collectedItem = Instantiate(CollectedItemPrefab, position , Quaternion.AngleAxis(0, Vector3.up));
    }
}
