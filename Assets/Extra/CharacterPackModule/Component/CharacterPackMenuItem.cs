using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterPackMenuItem : MonoBehaviour
{
    public Text buttonText;
    public Text countText;
    public Button selfButton;
    public CCharacterBasicModule characterBasicModule;

    public void Start()
    {
        selfButton.onClick.AddListener(delegate
        {
            if(characterBasicModule!=null)
            characterBasicModule.Hunger += 10;
        });
    }

    private void OnEnable()
    {
        characterBasicModule = null;
    }
}
