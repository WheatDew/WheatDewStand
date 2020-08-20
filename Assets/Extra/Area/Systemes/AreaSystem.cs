using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class AreaSystem : ComponentSystem
{

    protected override void OnStartRunning()
    {
        Entities.ForEach((Area area) => {
            area.CharacterInside = area.AreaTrigger.CharacterInsideList;
            area.CharacterOutside = area.AreaTrigger.CharacterOutsideList;
        });
    }

    protected override void OnUpdate()
    {
        Entities.ForEach((Area area) => {
            foreach(var item in area.CharacterInside)
            {
                item.GetComponent<CharacterStatus>().Action = area.CharacterActionAssign;
            }
            area.CharacterInside.Clear();
            foreach(var item in area.CharacterOutside)
            {
                item.GetComponent<CharacterStatus>().Action = "";
            }
            area.CharacterOutside.Clear();
        });

        Entities.ForEach((CharacterStatus characterStatus,CharacterPack characterPack) => {
            if (characterStatus.Action.Equals("获取"))
            {
                characterStatus.ActionValue += Time.DeltaTime;

                if (characterStatus.ActionValue > 1)
                {
                    if (characterPack.Pack.ContainsKey("材料"))
                    {
                        characterPack.Pack["材料"]++;
                        Debug.Log("材料+1");
                    }
                    else
                        characterPack.Pack.Add("材料", 1);
                    characterStatus.ActionValue = 0;
                }
            }
        });
    }
}
