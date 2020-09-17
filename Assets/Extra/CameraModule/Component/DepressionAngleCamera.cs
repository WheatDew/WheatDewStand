using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepressionAngleCamera : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0)||Input.GetMouseButton(2))
        transform.position -= new Vector3(Input.GetAxis("Mouse X"), 0 , Input.GetAxis("Mouse Y"));

        transform.position -= new Vector3(0, Input.GetAxis("Mouse ScrollWheel")*10, 0);
    }
}
