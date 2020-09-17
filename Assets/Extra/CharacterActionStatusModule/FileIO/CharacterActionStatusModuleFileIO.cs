using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterActionStatusModuleFileIO : MonoBehaviour
{
    public Dictionary<string, Texture> SpriteAssetsList = new Dictionary<string, Texture>();

    public Texture[] VirtualFileGroup;

    private void Start()
    {
        VirtualReadFile();
    }

    public void VirtualReadFile()
    {
        foreach(var item in VirtualFileGroup)
        {
            SpriteAssetsList.Add(item.name, item);
        }
    }
}
