using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBox : MonoBehaviour
{
    public float xMovement=0;
    public float yMovement=0;
    public float zMovement=0;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(xMovement, yMovement, zMovement), Space.Self);
    }
}
