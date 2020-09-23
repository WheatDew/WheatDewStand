using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCharacterPack : MonoBehaviour
{
    public Dictionary<string, int> Pack = new Dictionary<string, int>();
    public Stack<TCharacterPack> TaskList = new Stack<TCharacterPack>();
}
