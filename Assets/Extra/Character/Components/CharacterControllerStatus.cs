using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerStatus : MonoBehaviour
{
    /// <summary>
    /// 征召选择状态
    /// </summary>
    public bool isConscriptSelected;

    /// <summary>
    /// 测试选择状态
    /// </summary>
    public bool isTestSelected;
    

    [NonSerialized]
    public Transform CharacterDialogueWith;

    public string ContentDialogueWith;

    public MeshRenderer StatusBubble;

    public GameObject StatusBubbleObject;
}
