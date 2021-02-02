using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneModuleSpawner : MonoBehaviour
{
    //地形
    [SerializeField]
    private GameObject testTerrain;
    [System.NonSerialized]
    public GameObject currentScene;

    //地形贴图生成器
    [SerializeField]
    private EnvironmentModuleSpawner EnvironmentModuleSpawner;
    [System.NonSerialized]
    private EnvironmentModuleSpawner currentEnvironmentModuleSpawner;


    private void Start()
    {
        currentScene = Instantiate(testTerrain);
        currentEnvironmentModuleSpawner = Instantiate(EnvironmentModuleSpawner);
        currentEnvironmentModuleSpawner.terrain = currentScene.GetComponent<Terrain>();
    }
}
