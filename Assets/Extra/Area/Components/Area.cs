using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area : MonoBehaviour
{
    public AreaTrigger AreaTrigger;
    public HashSet<GameObject> CharacterInside;
    public HashSet<GameObject> CharacterOutside;

    public string CharacterActionAssign;
}
