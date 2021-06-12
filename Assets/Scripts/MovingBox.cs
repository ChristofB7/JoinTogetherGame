using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBox : MonoBehaviour
{
    public float xMovement=0;
    public float yMovement=0;
    public float zMovement=0;
    public float speed =1;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = xMovement * Time.deltaTime * speed;
        float y = yMovement * Time.deltaTime * speed;
        float z = zMovement * Time.deltaTime * speed;
        transform.Translate(new Vector3(x, y, z), Space.Self);
    }
}
