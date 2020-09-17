using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class PackPageSystem : ComponentSystem
{
    private PackPage AssignPackPage=null;

    protected override void OnUpdate()
    {
        ExecutePackPageTaskList();
        PackPageUpdateJob();
    }

    public void ExecutePackPageTaskList()
    {
        Entities.ForEach((PackPage packPage) =>
        {
            while (packPage.packPageTaskList.Count > 0)
            {
                var task = packPage.packPageTaskList.Pop();
                if (task.OpenPackPage)
                {
                    packPage.Display.SetActive(true);
                    packPage.Open = true;
                    AssignPackPage = packPage;
                }
                else
                {
                    packPage.Display.SetActive(false);
                    packPage.Open = false;
                    AssignPackPage = null;
                }
            }
        });
    }

    public void PackPageUpdateJob()
    {
        if(AssignPackPage != null)
        Entities.ForEach((CharacterPack characterPack, CharacterControllerStatus status) => {
            if (status.isConscriptSelected && AssignPackPage.Display.activeSelf)
            {
                int i = 0;
                foreach(var item in AssignPackPage.ItemList)
                {
                    item.gameObject.SetActive(false);
                }

                foreach (var item in characterPack.Pack)
                {
                    AssignPackPage.ItemList[i].gameObject.SetActive(true);
                    AssignPackPage.ItemList[i].SetValue(item.Key, item.Value);
                    i++;
                }
            }
        });
    }

}
