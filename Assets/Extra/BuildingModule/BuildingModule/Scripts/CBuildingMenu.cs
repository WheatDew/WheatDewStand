using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CBuildingMenu : MonoBehaviour
{
    public bool t1, t2, t3;
    public Button b1, b2, b3;


    // Update is called once per frame
    void Update()
    {
        if (!t1)
            b1.gameObject.SetActive(false);
        if (!t2)
            b2.gameObject.SetActive(false);
        if (!t3)
            b3.gameObject.SetActive(false);
    }
}
