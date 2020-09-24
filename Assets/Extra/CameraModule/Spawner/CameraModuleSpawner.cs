using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraModuleSpawner : MonoBehaviour
{
    [SerializeField]
    private DepressionAngleCamera depressionAngleCamera;
    [System.NonSerialized]
    public DepressionAngleCamera currentDepressionAngleCamera;

    private void Start()
    {
        currentDepressionAngleCamera = Instantiate(depressionAngleCamera);
    }


}
