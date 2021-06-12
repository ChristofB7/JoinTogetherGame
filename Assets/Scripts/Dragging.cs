using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragging : MonoBehaviour
{
    public GameObject objectAttachedTo;
    public float distance = 20f;
    public float pullSpeed = 600f;
    public GameObject cam;

    private GameObject fake;

    // Start is called before the first frame update
    void Start()
    {
        fake = new GameObject();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (Vector3.Distance(objectAttachedTo.transform.position, transform.position) >= distance)
        {
            transform.LookAt(objectAttachedTo.transform);
            GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * pullSpeed, ForceMode.Force);
            //transform.rotation = Quaternion.Euler(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));
        }
    }
}
