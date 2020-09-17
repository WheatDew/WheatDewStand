using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkbenchCollider : MonoBehaviour
{
    public Workbench workbench;

    private void OnMouseEnter()
    {
        workbench.isOver = true;
    }

    private void OnMouseExit()
    {
        workbench.isOver = false;
    }
}
