using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MWorkbench : MonoBehaviour
{
    [SerializeField]
    private CollectedItemModelUIGroup collectedItemModelUIGroup;
    [SerializeField]
    private EWorkbench workbenchModuleSpawnerExpansion;
    [System.NonSerialized]
    public EWorkbench currentWorkbenchModuleSpawnerExpansion;
    [SerializeField]
    private GameObject WorkbenchPrefab;

    private void Start()
    {
        //currentWorkbenchModuleSpawnerExpansion = Instantiate(collectedItemModelUIGroup, FindObjectOfType<Canvas>().transform);
        //ECollectedItemModel tempSpawnerExpansion = Instantiate(workbenchModuleSpawnerExpansion);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
            CreateCollectedItem(new Vector3(6, 0, 6));
    }

    public void CreateCollectedItem(Vector3 position)
    {
        GameObject collectedItem = Instantiate(WorkbenchPrefab, position, Quaternion.AngleAxis(0, Vector3.up));
    }
}
