using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkbenchMenu : MonoBehaviour
{
    public WorkbenchMenuController workbenchMenuController;
    private void OnDisable()
    {
        foreach(var item in workbenchMenuController.workbenchMenuItemList)
        {
            item.gameObject.SetActive(false);
        }
    }
}
