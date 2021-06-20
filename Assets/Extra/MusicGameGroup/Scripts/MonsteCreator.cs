using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsteCreator : MonoBehaviour
{
    public float x, y;
    public GameObject monster;

    private void Start()
    {
        StartCoroutine(Spawner());
    }

    IEnumerator Spawner()
    {
        while (true)
        {
            Instantiate(monster, new Vector3(Random.Range(-x, x), 0, Random.Range(-y, y)), monster.transform.rotation);
            yield return new WaitForSeconds(2);
        }
    }
}
