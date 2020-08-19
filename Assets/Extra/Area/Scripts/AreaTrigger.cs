using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaTrigger : MonoBehaviour
{
    public HashSet<GameObject> CharacterInsideList = new HashSet<GameObject>();
    public HashSet<GameObject> CharacterOutsideList = new HashSet<GameObject>();

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag.Equals("Character"))
        {
            CharacterInsideList.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("Character"))
        {
            CharacterOutsideList.Add(other.gameObject);
        }
    }
}
