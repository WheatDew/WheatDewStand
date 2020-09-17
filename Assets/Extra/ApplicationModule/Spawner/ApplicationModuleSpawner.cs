using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplicationModuleSpawner : MonoBehaviour
{
    [SerializeField]
    private ApplicationController applicationController;
    [System.NonSerialized]
    public ApplicationController currentApplicationController;

    private void Start()
    {
        currentApplicationController = Instantiate(applicationController);
    }
}
