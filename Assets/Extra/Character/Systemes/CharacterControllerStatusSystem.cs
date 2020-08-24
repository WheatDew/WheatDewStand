using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class CharacterControllerStatusSystem : ComponentSystem
{
    public CharacterControllerStatus ConscriptCharacter;

    protected override void OnUpdate()
    {
        Entities.ForEach((CharacterControllerStatus status) => {
            if (status.isConscriptSelected)
            {
                ConscriptCharacter = status;
            }
        });
    }
}
