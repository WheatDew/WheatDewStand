using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;


public class CharacterBasicModuleNormalSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject CharacterBasicModuleAssignPrefab;
    [System.NonSerialized]
    public GameObject CharacterBasicModulePrefab;
    [SerializeField]
    private UCharacterStatus characterStatusUIPrefab;

    private void Awake()
    {
        CharacterBasicModulePrefab = Instantiate(CharacterBasicModuleAssignPrefab);
        CharacterBasicModulePrefab.name = "CharacterOrigin";
    }

    private void Start()
    {
        UCharacterStatus characterStatusUI = Instantiate(characterStatusUIPrefab, transform);
        World.DefaultGameObjectInjectionWorld.GetExistingSystem<SCharacterBasicModule>().CharacterStatusUI = characterStatusUI;
    }

    public void Update()
    {
        //测试
        if (Input.GetKeyDown(KeyCode.F))
        {
            CreateCharacterBasicModule();
        }

    }

    public void TestInitialization()
    {
        CreateCharacterBasicModule();
    }

    public void CreateCharacterBasicModule()
    {
        GameObject characterBasicModuleObject = Instantiate(CharacterBasicModulePrefab);
        characterBasicModuleObject.SetActive(true);
    }
}
