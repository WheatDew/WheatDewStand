using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPack : MonoBehaviour
{
    public bool isDisplay;
    public Stack<ItemTask> ItemChangeTaskList = new Stack<ItemTask>();
    public Dictionary<string, int> Pack = new Dictionary<string, int>();
}
