using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class target : MonoBehaviour
{

    public GameObject sphere;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(sphere.transform.position.x, 1.5f, sphere.transform.position.z);
    }
}
