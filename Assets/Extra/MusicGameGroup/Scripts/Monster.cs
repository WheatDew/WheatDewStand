using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monster : MonoBehaviour
{
    private NavMeshAgent agent;
    public GameObject dead;
    private Character2DMovingController c2mc;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        c2mc = FindObjectOfType<Character2DMovingController>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = c2mc.character.transform.position;
        if (Input.GetKeyDown(KeyCode.K))
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name=="sword")
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        Instantiate(dead,transform.position,dead.transform.rotation);
    }
}
