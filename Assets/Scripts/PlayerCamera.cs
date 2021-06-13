using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour {
    public float rotationSpeed;
    public float zoomSpeed = 1;
    public Transform target;
    float mouseX, mouseY;
    public LayerMask cameraLayer;



    // Start is called before the first frame update
    void Start()
    {
        rotationSpeed = PlayerPrefs.GetFloat("sens");
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = new Vector3(target.position.x, target.position.y, target.position.z - 4.5f);
        CamControl();
    }

    void CamControl()
    {

        mouseX += Input.GetAxis("Mouse X") * rotationSpeed;
        mouseY -= Input.GetAxis("Mouse Y") * rotationSpeed;



        mouseY = Mathf.Clamp(mouseY, -90, 90);
        transform.LookAt(target);


        target.rotation = Quaternion.Euler(mouseY, mouseX, 0f);
    }
}
