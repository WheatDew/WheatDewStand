using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterActionStatusModuleNormalSpawnerExpansion : MonoBehaviour
{
    public CharacterActionStatusBubble characterActionStatusBubblePrefab;

    private void Start()
    {
        GameObject CharacterBasicModulePrefab = FindObjectOfType<CharacterBasicModuleNormalSpawner>().CharacterBasicModulePrefab;
        CCharacterActionStatus characterActionStatus= CharacterBasicModulePrefab.AddComponent<CCharacterActionStatus>();
        CharacterActionStatusBubble characterActionStatusBubble = Instantiate(characterActionStatusBubblePrefab, CharacterBasicModulePrefab.transform);
        characterActionStatus.characterActionStatusBubble = characterActionStatusBubble;
    }
}
