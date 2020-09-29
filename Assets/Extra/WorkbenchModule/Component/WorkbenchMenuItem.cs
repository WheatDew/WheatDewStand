using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorkbenchMenuItem : MonoBehaviour
{
    public Text buttonText;
    public Button selfButton;
    private CCharacterWorkbenchAbility characterWorkbenchAbility;
    private CWorkbench workbench;

    public void Start()
    {
        selfButton.onClick.AddListener(delegate
        {
            characterWorkbenchAbility.workbenchTarget = workbench;
        });
    }

    public void Initialization(string buttonText, CCharacterWorkbenchAbility characterWorkbenchAbility , CWorkbench workbench)
    {
        this.buttonText.text = buttonText;
        this.characterWorkbenchAbility = characterWorkbenchAbility;
    }
}
