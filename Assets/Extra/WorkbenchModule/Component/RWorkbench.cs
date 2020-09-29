using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RWorkbench : MonoBehaviour
{
    public RectTransform rectTransform;
    public Transform itemParent;
    public WorkbenchMenuItem workBenchMenuItemPrefab;

    public void CreateItem(string buttonName, CCharacterWorkbenchAbility workbenchAbility, CWorkbench workbench)
    {
        WorkbenchMenuItem TempWorkbenchMenuItem = Instantiate(workBenchMenuItemPrefab, itemParent);
        TempWorkbenchMenuItem.Initialization(buttonName, workbenchAbility, workbench);
    }

    private void OnEnable()
    {
        for (int i = 0; i < itemParent.childCount; i++)
        {
            Destroy(itemParent.GetChild(i).gameObject);
        }
    }
}
