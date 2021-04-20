using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueSpawner : MonoBehaviour
{
    public DialogueController dialogueControllerPrefab;
    public DialogueController dialogueController;

    private void Start()
    {
        dialogueController = Instantiate(dialogueControllerPrefab, FindObjectOfType<Canvas>().transform);
    }
}
