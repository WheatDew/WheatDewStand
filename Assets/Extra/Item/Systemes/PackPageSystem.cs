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
            Debug.Log("PackPage Initialization Successful");
        });
    }

    protected override void OnUpdate()
    {
        PackPageJob();

        PackUIGroupJob();
    }

    public void PackPageJob()
    {
        Entities.ForEach((CharacterPack characterPack, CharacterControllerStatus status) => {
            if (status.isConscriptSelected && packPageUI.Display.activeSelf)
            {
                int i = 0;
                foreach (var item in characterPack.Pack)
                {
                    packPageUI.ItemList[i].gameObject.SetActive(true);
                    packPageUI.ItemList[i].SetValue(item.Key, item.Value);
                    i++;
                }
            }
        });
    }

    public void PackUIGroupJob()
    {
        Entities.ForEach((PackUIGroup packUIGroup) =>
        {
            if (packUIGroup.command.Equals("Open"))
            {
                if (!packPageUI.Display.activeSelf)
                    packPageUI.Display.SetActive(true);
                else
                    packPageUI.Display.SetActive(false);
                packUIGroup.command = "";
            }
        });
    }

}
