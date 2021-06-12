using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moveable : MonoBehaviour
{

    public Camera cam;
    public Camera PlayerCamera;

    // Start is called before the first frame update
    void Start()
    {
        cam.gameObject.GetComponent<AudioListener>().enabled = false;
        cam.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            LeaveObject();
        }

    }

    private void LeaveObject()
    {
        cam.enabled = false;
        cam.gameObject.GetComponent<AudioListener>().enabled = false;
        PlayerCamera.enabled = true;
        PlayerCamera.gameObject.GetComponent<AudioListener>().enabled = true;
    }
}
