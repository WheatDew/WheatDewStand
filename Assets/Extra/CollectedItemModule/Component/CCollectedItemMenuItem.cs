using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CCollectedItemMenuItem : MonoBehaviour
{
    public Text buttonText;
    public Button selfButton;
    private CCharacterCollectedAbility characterCollectedAbility;
    private CCollectedItem collectedItem;

    public void Start()
    {
        selfButton.onClick.AddListener(delegate
        {
            characterCollectedAbility.CollectedItemTarget = collectedItem;
        });
    }

    public void Initialization(string buttonText,CCharacterCollectedAbility characterCollectedAbility,CCollectedItem collectedItem)
    {
        this.buttonText.text = buttonText;
        this.characterCollectedAbility = characterCollectedAbility;
        this.collectedItem = collectedItem;
    }
}
