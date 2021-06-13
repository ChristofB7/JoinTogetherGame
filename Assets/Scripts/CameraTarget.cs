using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTarget : MonoBehaviour
{



    public GameObject sphere;
    public float turnStrength = 180f;
    private float turnInput;
    private bool win;

    // Start is called before the first frame update
    void Start()
    {
        win = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(sphere.transform.position.x, sphere.transform.position.y + 1.5f,
        sphere.transform.position.z);
        //turnInput = Input.GetAxis("Horizontal");
        //transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0f, turnInput * turnStrength * Time.deltaTime * Input.GetAxis("Vertical"), 0f));

    }
}
