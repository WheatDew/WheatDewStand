using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerStatus : MonoBehaviour
{
    public bool isConscriptSelected;

    [NonSerialized]
    public Transform CharacterDialogueWith;

    public string ContentDialogueWith;

    public MeshRenderer StatusBubble;

    public GameObject StatusBubbleObject;
}
