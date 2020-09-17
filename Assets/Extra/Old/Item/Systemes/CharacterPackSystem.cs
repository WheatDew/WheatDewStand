using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;
using UnityEngine.Events;

public class CharacterPackSystem : ComponentSystem
{
    protected override void OnUpdate()
    {
        Entities.ForEach((CharacterPack characterPack) =>
        {
            while (characterPack.ItemChangeTaskList.Count>0)
            {
                var task = characterPack.ItemChangeTaskList.Pop();
                if(CharacterPackRemoveItem(characterPack,task.Losing))
                    CharacterPackAddItem(characterPack, task.Getting);
            }
        });
    }

    public void CharacterPackAddItem(CharacterPack characterPack, params string[] items)
    {
        foreach (var item in items)
        {
            if (characterPack.Pack.ContainsKey(item))
                characterPack.Pack[item]++;
            else
            {
                characterPack.Pack.Add(item, 1);
            }
        }
    }

    public bool CharacterPackRemoveItem(CharacterPack characterPack, params string[] items)
    {
        UnityAction ua = delegate { };

        foreach (var item in items)
        {
            if (characterPack.Pack.ContainsKey(item))
            {
                if (characterPack.Pack[item] - 1 == 0)
                {
                    ua += delegate { characterPack.Pack.Remove(item); };
                }
                else if (characterPack.Pack[item] - 1 < 0)
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
