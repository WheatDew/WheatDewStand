using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class ActionSystem : ComponentSystem
{
    Dictionary<string, Texture> iconPair = new Dictionary<string, Texture>();

    protected override void OnStartRunning()
    {
        //初始化IconDictionary
        Entities.ForEach((IconDictionary dic) =>{
            for(int i = 0; i < dic.IconName.Length; i++)
            {
                iconPair.Add(dic.IconName[i], dic.Icon[i]);
            }
        });
        Debug.Log("IconDictionary Initialization Successful");
    }

    protected override void OnUpdate()
    {
        Entities.ForEach((CharacterStatus status,CharacterControllerStatus controllerStatus) => {
            if(iconPair.ContainsKey(status.Action))
            {
                controllerStatus.StatusBubble.material.SetTexture(1, iconPair[status.Action]);
            }
        });
    }
}
