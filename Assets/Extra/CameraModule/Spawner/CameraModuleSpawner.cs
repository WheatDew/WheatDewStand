using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraModuleSpawner : MonoBehaviour
{
    [SerializeField]
    public DepressionAngleCamera depressionAngleCamera;
    [System.NonSerialized]
    private DepressionAngleCamera currentDepressionAngleCamera;

    private void Start()
    {
        currentDepressionAngleCamera = Instantiate(depressionAngleCamera);
    }
}
