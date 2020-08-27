using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkbenchCollider : MonoBehaviour
{
    Workbench workbench;

    private void OnMouseEnter()
    {
        workbench.isOver = true;
    }

    private void OnMouseExit()
    {
        workbench.isOver = false;
    }
}
