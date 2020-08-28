using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class WorkbenchMenuSystem : ComponentSystem
{

    bool isDisplayingWorkBenchMenu;


    protected override void OnUpdate()
    {
        
    }

    public void ExcuteWorkbenchJob()
    {
        if (isDisplayingWorkBenchMenu)
        {
            Entities.ForEach((WorkbenchMenu workbenchMenu) => {
                
            });
        }
    }

    public void ClickWorkbenchJob()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Entities
                .ForEach((Workbench workbench) =>
            {
                if (workbench.isOver)
                {
                    isDisplayingWorkBenchMenu = true;
                }
            });
        }

    }
}
