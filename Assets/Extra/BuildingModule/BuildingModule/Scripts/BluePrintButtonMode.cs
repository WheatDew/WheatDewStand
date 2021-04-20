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
        RaycastHit raycastHit;
        Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out raycastHit);

        if (Input.GetMouseButtonDown(0)&&basicBuidingAssign!=null)
        {
            if (raycastHit.point != Vector3.zero)
            {
                BasicBuiding obj = Instantiate(basicBuidingAssign, raycastHit.point, basicBuidingAssign.transform.rotation);
            }

        }
        else if (Input.GetMouseButtonDown(1))
        {
            basicBuidingAssign = null;
        }

    }
}
