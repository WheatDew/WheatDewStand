using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterRabbit : MonoBehaviour
{
    public GameObject dead;
    public Animator ani;
    public SpriteRenderer sr;
    private Character2DMovingController c2mc;
    // Start is called before the first frame update
    void Start()
    {
        c2mc = FindObjectOfType<Character2DMovingController>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "sword")
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
