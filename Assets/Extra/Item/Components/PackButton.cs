using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PackButton : MonoBehaviour
{
    public GameObject targetObj;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(delegate
        {
            if (targetObj.activeSelf)
                targetObj.SetActive(false);
            else
                targetObj.SetActive(true);
        });
    }
}
