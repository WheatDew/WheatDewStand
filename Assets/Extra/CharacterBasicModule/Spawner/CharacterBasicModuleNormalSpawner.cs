using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBasicModuleNormalSpawner : MonoBehaviour
{
    public GameObject CharacterBasicModulePrefab;

    private void Start()
    {
        TestInitialization();
    }

    public void TestInitialization()
    {
        CreateCharacterBasicModule();
    }

    public void CreateCharacterBasicModule()
    {
        GameObject characterBasicModuleObject = Instantiate(CharacterBasicModulePrefab);
    }
}
