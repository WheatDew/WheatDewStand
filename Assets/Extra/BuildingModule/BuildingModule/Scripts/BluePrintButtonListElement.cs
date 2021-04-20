using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BluePrintButtonListElement : MonoBehaviour
{
    public BasicBuiding basicBuiding;
    public BluePrintButtonMode bluePrintButtonMode;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(AssignBasicBuidingButton);
    }

    public void AssignBasicBuidingButton()
    {
        bluePrintButtonMode.basicBuidingAssign = basicBuiding;
    }
}
