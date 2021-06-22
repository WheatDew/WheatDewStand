using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDead : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ds_self());
    }

    public IEnumerator ds_self()
    {

        yield return new WaitForSeconds(2);

        Destroy(gameObject);

    }

}
