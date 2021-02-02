using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BluePrintButton : MonoBehaviour
{
    private Button button;

    [SerializeField]
    private BluePrintButtonMode bluePrintButtonModePrefab;
    [System.NonSerialized]
    public BluePrintButtonMode currentBluePrintButtonMode;

    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(delegate
        {
            if (currentBluePrintButtonMode==null)
                currentBluePrintButtonMode = Instantiate(bluePrintButtonModePrefab,FindObjectOfType<Canvas>().transform);
            else
                Destroy(currentBluePrintButtonMode.gameObject);

        });
    }

}
