using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class accel : MonoBehaviour
{
    private CarController car;
    private Dragging drag;


    void OnCollisionStay(Collision collision)
    {

        if (drag == null)
        {
            drag = FindObjectOfType<Dragging>();
        }
        
        if(collision.gameObject.layer == 11 && Input.GetAxis("Vertical")>0)
        {
            car.forwardAccel += 35f*Time.deltaTime;
            drag.pullSpeed = 40f;
            drag.distance = 2f;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        car = FindObjectOfType<CarController>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
