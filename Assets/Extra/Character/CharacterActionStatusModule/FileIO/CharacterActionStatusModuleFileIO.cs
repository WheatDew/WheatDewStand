using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterActionStatusModuleFileIO : MonoBehaviour
{
    public Dictionary<int, Texture> SpriteAssetsList = new Dictionary<int, Texture>();

    public Texture[] VirtualFileGroup;

    private void Start()
    {
        VirtualReadFile();
    }

    public void VirtualReadFile()
    {
        for(int i = 0; i < VirtualFileGroup.Length; i++)
        {
            SpriteAssetsList.Add(i, VirtualFileGroup[i]);
        }
    }
}
