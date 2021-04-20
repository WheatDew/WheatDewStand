using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBuiding : MonoBehaviour
{
    public SpriteRenderer display;
    public bool isFloat;

    public void Update()
    {
        if (isFloat)
        {
            RaycastHit result;
            if (Physics.Raycast(Camera.main.ViewportPointToRay(Input.mousePosition), out result))
            {
                gameObject.SetActive(true);
                transform.position = result.point;
            }
            else
            {
                gameObject.SetActive(false);
            }

        }
    }
}
