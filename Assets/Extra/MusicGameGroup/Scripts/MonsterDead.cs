using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDead : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("ds_self", 2);
    }

    public void ds_self()
    {
        Destroy(gameObject);
    }

    
    // Update is called once per frame
    void Update()
    {
        
    }
}
