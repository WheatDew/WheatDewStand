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

            foreach (var item in area.CharacterOutside)
            {
                CharacterArea chaAreaInfo = item.GetComponent<CharacterArea>();
                CharacterStatus chaStatus = item.GetComponent<CharacterStatus>();
                chaStatus.Action = "";
                chaAreaInfo.AreaInside = "";
                chaAreaInfo.AreaItemGetting = new string[0];
                chaAreaInfo.AreaItemLosing = new string[0];
                chaAreaInfo.ActionTimer = 0;
                chaAreaInfo.AreaMultiplier = 1;
            }
            area.CharacterOutside.Clear();

            foreach (var item in area.CharacterInside)
            {
                CharacterArea chaAreaInfo=item.GetComponent<CharacterArea>();
                CharacterStatus chaStatus = item.GetComponent<CharacterStatus>();
                chaStatus.Action = area.CharacterActionAssign;
                chaAreaInfo.AreaInside = area.AreaName;
                chaAreaInfo.AreaItemGetting = area.ItemGetting;
                chaAreaInfo.AreaItemLosing = area.ItemLosing;
                chaAreaInfo.ActionTimerInterval = area.TimerInterval;
                chaAreaInfo.ActionTimer = 0;

            }
            area.CharacterInside.Clear();
            
        });

    }
}
