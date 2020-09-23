using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterPackMenuItem : MonoBehaviour
{
    public Text buttonText;
    public Button selfButton;

    public void Start()
    {
        selfButton.onClick.AddListener(delegate
        {
            
        });
    }

    public void Initialization(string buttonText)
    {
        this.buttonText.text = buttonText;
    }
}
