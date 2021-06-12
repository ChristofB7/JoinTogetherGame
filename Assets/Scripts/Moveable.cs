using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moveable : MonoBehaviour
{

    public float speed = 300f;
    private Rigidbody moveableBody;
    public GameObject target;
    public Camera cam;
    public Camera PlayerCamera;

    // Start is called before the first frame update
    void Start()
    {
        moveableBody = GetComponent<Rigidbody>();
        cam = target.transform.GetChild(0).GetComponent<Camera>();
        cam.gameObject.GetComponent<AudioListener>().enabled = false;
        cam.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (cam.enabled)
        {
            Move();
        }
        if (Input.GetMouseButtonDown(0))
        {
            LeaveObject();
        }

    }

    private void Move()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        Vector3 playerMovement = new Vector3(hor, 0f, ver) * speed * Time.deltaTime;
        //playerBody.AddForce(playerMovement);
        Debug.Log("We moving!");
        moveableBody.AddForce(target.transform.forward * ver * speed * Time.deltaTime);
        moveableBody.AddForce(target.transform.right * hor * speed * Time.deltaTime);
    }

    private void LeaveObject()
    {
        cam.enabled = false;
        cam.gameObject.GetComponent<AudioListener>().enabled = false;
        PlayerCamera.enabled = true;
        PlayerCamera.gameObject.GetComponent<AudioListener>().enabled = true;
    }
}
