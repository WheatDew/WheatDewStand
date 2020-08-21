using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class PackPageSystem : ComponentSystem
{
    PackPage packPage;

    protected override void OnStartRunning()
    {
        Entities.ForEach((PackPage packPage) => {
            this.packPage = packPage;
            Debug.Log("PackPage Initialization Successful");
        });
    }

    protected override void OnUpdate()
    {
        PackPageUpdateJob();
    }

    public void PackPageUpdateJob()
    {
        Entities.ForEach((CharacterPack characterPack, CharacterControllerStatus status) => {
            if (status.isConscriptSelected && packPage.Display.activeSelf)
            {
                int i = 0;
                foreach (var item in characterPack.Pack)
                {
                    packPage.ItemList[i].gameObject.SetActive(true);
                    packPage.ItemList[i].SetValue(item.Key, item.Value);
                    i++;
                }
            }
        });
    }

    public void PackButtonInitJob()
    {
        
    }

}
