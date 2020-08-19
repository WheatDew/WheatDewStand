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
    }
}
