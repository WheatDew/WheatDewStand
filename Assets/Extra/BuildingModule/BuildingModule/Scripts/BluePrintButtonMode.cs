using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BluePrintButtonMode : MonoBehaviour
{
    public BasicBuiding basicBuidingAssign;

    private void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)&&basicBuidingAssign!=null)
        {
            RaycastHit raycastHit;
            Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out raycastHit);
            if (raycastHit.point != Vector3.zero)
            {
                BasicBuiding obj = Instantiate(basicBuidingAssign, raycastHit.point, basicBuidingAssign.transform.rotation);
            }

        }   

    }
}
