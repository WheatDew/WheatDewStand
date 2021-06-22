using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monster : MonoBehaviour
{
    private NavMeshAgent agent;
    public GameObject dead;
    public Animator ani;
    public SpriteRenderer sr;
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
        if (agent.destination.x < transform.position.x)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name=="sword")
        {
            if (dead != null)
                Instantiate(dead, transform.position, Quaternion.Euler(90, 0, 0));
            Destroy(gameObject);
        }
        if (other.gameObject.name == "player")
        {
            StartCoroutine(bomb());
        }
    }

    public IEnumerator bomb()
    {
        sr.color = Color.red;
        yield return new WaitForSeconds(0.5f);
        Instantiate(dead, transform.position, Quaternion.Euler(90, 0, 0));
        Destroy(gameObject);
    }
}
