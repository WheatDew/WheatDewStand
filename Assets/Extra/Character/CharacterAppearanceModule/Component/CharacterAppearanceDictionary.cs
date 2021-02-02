using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class CharacterAppearanceDictionary : MonoBehaviour
{
    public Texture[] RawTextureArray;
    public string[] characterName;
    public Dictionary<string, Texture4> TextureDictionary = new Dictionary<string, Texture4>();

    private void Start()
    {
        for(int i = 0; i < RawTextureArray.Length-3; i+=4)
        {
            Texture4 tempTexture4 = new Texture4();
            tempTexture4.east = RawTextureArray[i];
            tempTexture4.west = RawTextureArray[i + 1];
            tempTexture4.south = RawTextureArray[i + 2];
            tempTexture4.north = RawTextureArray[i + 3];
            TextureDictionary.Add(characterName[i/4],tempTexture4);
        }
        World.DefaultGameObjectInjectionWorld.GetExistingSystem<SCharacterApperanceModule>().appearanceDictionary = this;
    }
}

public struct Texture4
{
    public Texture east, west, south, north;
}
