using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterBasicModuleNormalSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject CharacterBasicModuleAssignPrefab;
    [System.NonSerialized]
    public GameObject CharacterBasicModulePrefab;

    private void Awake()
    {
        CharacterBasicModulePrefab = Instantiate(CharacterBasicModuleAssignPrefab);
        CharacterBasicModulePrefab.name = "CharacterOrigin";
    }

    private void Start()
    {
        
    }

    public void Update()
    {
        //测试
        if(Input.GetKeyDown(KeyCode.F))
        CreateCharacterBasicModule();
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
