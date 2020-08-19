using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class PackPageSystem : ComponentSystem
{
    PackPage packPageUI;

    protected override void OnStartRunning()
    {
        Entities.ForEach((PackPage packPage) => {
            packPageUI = packPage;
        });
    }

    protected override void OnUpdate()
    {
        Entities.ForEach((CharacterPack characterPack,CharacterControllerStatus status) => {
            if (status.isConscriptSelected&&characterPack.isDisplay&&!packPageUI.Display.activeSelf)
            {
                packPageUI.Display.SetActive(true);
                int i = 0;
                foreach(var item in characterPack.Pack)
                {
                    packPageUI.ItemList[i].gameObject.SetActive(true);
                    packPageUI.ItemList[i].SetValue(item.Name, item.count);
                    i++;
                }
            }
        });

        Entities.ForEach((PackUIGroup packUIGroup) =>
        {
            if(packUIGroup.command.Equals("Open"))
            {
                packPageUI.Display.SetActive(true);
            }
        });
    }
}
