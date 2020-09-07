using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPack : MonoBehaviour
{
    public bool isDisplay;
    public List<ItemChangeTask> ItemChangeTaskList = new List<ItemChangeTask>();
    public Dictionary<string, int> Pack = new Dictionary<string, int>();
}
