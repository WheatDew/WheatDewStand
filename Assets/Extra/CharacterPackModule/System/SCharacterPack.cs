using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using UnityEngine.Events;

public class SCharacterPack : ComponentSystem
{
    public CharacterPackMenuController characterPackController;

    protected override void OnUpdate()
    {
        PackPageJob();
        CharacterPackTaskJob();
    }

    public void CharacterPackTaskJob()
    {
        Entities.ForEach((CCharacterPack characterPack) =>
        {
            while (characterPack.TaskList.Count > 0)
            {
                var task = characterPack.TaskList.Pop();
                if (CharacterPackRemoveItem(characterPack, task.Losing))
                    CharacterPackAddItem(characterPack, task.Getting);
            }
        });
    }

    public void PackPageJob()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (!characterPackController.gameObject.activeSelf)
            {
                Entities.ForEach((CCharacterPack pack) =>
                {
                    Debug.Log(pack.Pack.Count);
                    foreach (var item in pack.Pack)
                    {
                        characterPackController.CreateItem(item.Key);
                    }
                });
                characterPackController.gameObject.SetActive(true);
            }
            else
            {
                for(int i = 0; i < characterPackController.itemParent.childCount; i++)
                {
                    Object.Destroy(characterPackController.itemParent.GetChild(i));
                }
                characterPackController.gameObject.SetActive(false);
            }
        }
    }

    public void CharacterPackUpdataJob()
    {
        Entities.ForEach((CCharacterPack characterPack) =>
        {
            while (characterPack.TaskList.Count != 0)
            {
                TCharacterPack tempTask = characterPack.TaskList.Pop();
                if (CharacterPackRemoveItem(characterPack, tempTask.Losing))
                {
                    CharacterPackAddItem(characterPack, tempTask.Getting);
                }
                
            }

        });
    }

    public void CharacterPackAddItem(CCharacterPack characterPack, params string[] items)
    {
        foreach (var item in items)
        {
            if (characterPack.Pack.ContainsKey(item))
                characterPack.Pack[item]++;
            else
            {
                Debug.Log("添加新物品");
                characterPack.Pack.Add(item, 1);
            }
        }
    }

    public bool CharacterPackRemoveItem(CCharacterPack characterPack, params string[] items)
    {
        if (items.Length == 0)
        {
            Debug.Log("空消耗");
            return true;
        }
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
