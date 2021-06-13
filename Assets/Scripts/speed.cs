using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speed : MonoBehaviour
{

    Rigidbody rb;
    public float speedValue = 2f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(new Vector3(0,-1f,-1f)*speedValue*1000f);
    }
}
