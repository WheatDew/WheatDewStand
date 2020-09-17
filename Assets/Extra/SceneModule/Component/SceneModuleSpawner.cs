using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneModuleSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject testTerrain;
    [System.NonSerialized]
    public GameObject currentScene;

    private void Start()
    {
        currentScene = Instantiate(testTerrain);
    }
}
