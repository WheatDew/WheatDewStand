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
    public CCharacterPack characterPack;

    public void Start()
    {
        selfButton.onClick.AddListener(delegate
        {
            if (characterBasicModule != null)
            {
                characterBasicModule.Hunger += 10;
                characterPack.TaskList.Push(new TCharacterPack { Getting = new string[0] { }, Losing = new string[1] { buttonText.text } });
            }

        });
    }

    private void OnEnable()
    {
        characterBasicModule = null;
    }
}
