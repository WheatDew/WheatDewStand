using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Camera targetCamera;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(2))
        {
            targetCamera.transform.Translate(Vector3.down * Input.GetAxis("Mouse Y")*Time.deltaTime*40);
            targetCamera.transform.Translate(Vector3.left * Input.GetAxis("Mouse X")*Time.deltaTime*40);
        }
        targetCamera.transform.Translate(Vector3.forward * Input.GetAxis("Mouse ScrollWheel")*25);

    }
}
