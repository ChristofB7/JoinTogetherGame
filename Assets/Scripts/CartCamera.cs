using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartCamera : MonoBehaviour
{
    public float rotationSpeed;
    public float zoomSpeed = 1;
    public Transform target;
    float mouseX, mouseY;
    //public Transform obstruction;
    public LayerMask cameraLayer;
    private int cameraMode = 0;
    public Transform sphere;
    public Transform car;



    // Start is called before the first frame update
    void Start()
    {
        //obstruction = target;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        rotationSpeed = 1;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = new Vector3(target.position.x, target.position.y, target.position.z - 4.5f);
        CamControl();
        //ViewObstructed();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            cameraMode = (cameraMode + 1) % 2;
        }
    }

    void CamControl()
    {
        if (cameraMode == 0)
        {
            mouseX += Input.GetAxis("Mouse X") * rotationSpeed;
            mouseY -= Input.GetAxis("Mouse Y") * rotationSpeed;
        }
        /*if (cameraMode == 1)
        {
            target.rotation = car.rotation;
        }*/


        mouseY = Mathf.Clamp(mouseY, -90, 90);
        transform.LookAt(target);

        if (cameraMode == 0)
        {
            target.rotation = Quaternion.Euler(mouseY, mouseX, 0f);
        }
        if(cameraMode==1)
        {
            target.LookAt(sphere);
        }

    }

/*    void ViewObstructed()
    {
        RaycastHit hit;

        if(Physics.Raycast(transform.position, target.position - transform.position, out hit, 4.5f))
        {
            if(hit.collider.gameObject.tag != "Player")
            {
                obstruction = hit.transform;
                obstruction.gameObject.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly;

                //determines if the camera should hide the wall or move the camera closer
                if(Vector3.Distance(obstruction.position, transform.position)>= 3f && Vector3.Distance(transform.position, target.position) >= 1.5f)
                {
                    transform.Translate(Vector3.forward * zoomSpeed * Time.deltaTime);
                }
            }
            else if(obstruction.gameObject.layer != 9)
            {
                obstruction.gameObject.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
                if (Vector3.Distance(transform.position, target.position) < 4.5f)
                {
                    transform.Translate(Vector3.back * zoomSpeed * Time.deltaTime);
                }         
            }
        }
    }*/
}
