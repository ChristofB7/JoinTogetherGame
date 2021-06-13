using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelKiller : MonoBehaviour
{

    void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "barrel")
        {
            Destroy(collision.gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
