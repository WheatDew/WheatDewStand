using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAppearanceModuleSpawner : MonoBehaviour
{
    public Texture[] RawTextureArray;
    public string[] characterName;
    public CharacterAppearanceDictionary characterAppearanceDictionaryPrefab;
    public ECharacterAppearanceModuleSpawner characterAppearanceModuleExpansionSpawner;
    public void Start()
    {
        CharacterAppearanceDictionary characterAppearanceDictionary = Instantiate(characterAppearanceDictionaryPrefab, transform);
        characterAppearanceDictionary.RawTextureArray = this.RawTextureArray;
        characterAppearanceDictionary.characterName = this.characterName;
        ECharacterAppearanceModuleSpawner eCharacterAppearanceModuleSpawner = Instantiate(characterAppearanceModuleExpansionSpawner, transform);
    }
}
