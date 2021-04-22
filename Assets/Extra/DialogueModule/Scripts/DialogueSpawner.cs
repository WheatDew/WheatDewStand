using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueSpawner : MonoBehaviour
{
    [SerializeField]
    private DialogueController dialogueControllerPrefab;
    [System.NonSerialized]
    public DialogueController dialogueController;

    private void Start()
    {
        dialogueController = Instantiate(dialogueControllerPrefab, FindObjectOfType<Canvas>().transform);
    }
}
