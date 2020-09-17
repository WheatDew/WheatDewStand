using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Unity.Entities;
using UnityEngine;
using UnityEngine.Events;

public class AreaCharacterSystem : ComponentSystem
{
    protected override void OnUpdate()
    {
        Entities.ForEach((CharacterArea characterArea, CharacterPack characterPack) => {
            characterArea.ActionTimer += Time.DeltaTime;

            if (characterArea.ActionTimer > characterArea.ActionTimerInterval)
            {
                if(CharacerPackRemoveItem(characterPack,characterArea.AreaItemLosing))
                {
                    CharacterPackAddItem(characterPack, characterArea.AreaItemGetting);
                }
                characterArea.ActionTimer = 0;
            }
        });
    }

    public void CharacterPackAddItem(CharacterPack characterPack,params string[] items)
    {
        foreach(var item in items)
        {
            if (characterPack.Pack.ContainsKey(item))
                characterPack.Pack[item]++;
            else
            {
                characterPack.Pack.Add(item,1);
            }
        }
    }

    public bool CharacerPackRemoveItem(CharacterPack characterPack,params string[] items)
    {
        UnityAction ua=delegate { };

        foreach(var item in items)
        {
            if (characterPack.Pack.ContainsKey(item))
            {
                if (characterPack.Pack[item]-1 == 0)
                {
                    ua += delegate { characterPack.Pack.Remove(item); };
                }
                else if(characterPack.Pack[item]-1 < 0)
                {
                    return false;
                }
                else
                {
                    ua += delegate { characterPack.Pack[item]--; };
                }
            }
            else
                return false;
        }
        ua.Invoke();
        return true;
    }
}
