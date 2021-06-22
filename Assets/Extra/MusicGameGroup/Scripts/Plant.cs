using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    public GameObject dead;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "sword")
        {
            if (dead != null)
                Instantiate(dead, transform.position, Quaternion.Euler(90, 0, 0));
            Destroy(gameObject);
        }
    }
}
