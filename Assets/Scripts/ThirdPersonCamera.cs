using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public float rotationSpeed = 1;
    public Transform target;
    float mouseX, mouseY;
    public Transform obstruction;


    // Start is called before the first frame update
    void Start()
    {
        obstruction = target;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        CamControl();
    }

    void CamControl()
    {
        mouseX += Input.GetAxis("Mouse X") * rotationSpeed;
        mouseY -= Input.GetAxis("Mouse Y") * rotationSpeed;
        mouseY = Mathf.Clamp(mouseY, -35, 60);

        transform.LookAt(target);

        target.rotation = Quaternion.Euler(mouseY, mouseX, 0f);
        
    }
}
