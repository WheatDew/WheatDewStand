using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;


public class CharacterHungerSystem : ComponentSystem
{
    protected override void OnUpdate()
    {
        BeHungryJob();
    }

    void BeHungryJob()
    {
        Entities.ForEach((CharacterStatus status) => {
            if (status.HungerValue > 0)
                status.HungerValue -= 0.01f;
            else
                status.HungerValue = 0;
        });
    }
}
