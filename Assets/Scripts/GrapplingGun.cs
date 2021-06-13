using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrapplingGun : MonoBehaviour
{
    private LineRenderer lr;
    private Vector3 ballTip;
    private GameObject grappleObject;
    public LayerMask grappleLayer;
    public LayerMask movingLayer;
    public LayerMask moveableLayer;
    public Transform myCam;
    public float maxDistance = 100f;
    private SpringJoint joint;
    public GameObject sphere;
    bool isGrappling = false;
    private Dragging drag;
    public Image crosshair;
    public Sprite[] sprites;
    public float pullSpeed = 8f;


    private void Awake()
    {
        lr = GetComponent<LineRenderer>();
    }
    void Update()
    {
        /*float mwheel = Input.GetAxis("Mouse ScrollWheel");
        if (mwheel > 0 && joint)
        {
            joint.maxDistance *= 0.80f;
        }
        if(mwheel < 0 && joint)
        {
            joint.maxDistance *= 1.20f;
        }*/

        if (Input.GetMouseButtonDown(0))
        {
            if (isGrappling) { return; }
            isGrappling = true;
            StartGrapple();
        }
         if(Input.GetMouseButtonDown(1))
        {
            isGrappling = false;
            StopGrapple();
        }



        if (drag)
        {
            crosshair.sprite = sprites[0];
        }
        else
        {
            crosshair.sprite = sprites[1];
        }

    }

    private void LateUpdate()
    {
        DrawRope();
    }

    void StartGrapple()
    {

        
        RaycastHit hit;
/*        if(Physics.Raycast(myCam.position, myCam.forward, out hit, maxDistance, grappleLayer))
        {
            Hook(hit);
        }*/
        if(Physics.Raycast(myCam.position, myCam.forward, out hit, maxDistance, movingLayer))
        {
            //TODO: Hit Sound
            Drag(hit);

        }
        else if(Physics.Raycast(myCam.position, myCam.forward, out hit, maxDistance, moveableLayer))
        {
            myCam.gameObject.GetComponent<AudioListener>().enabled = false;
            
            hit.transform.gameObject.GetComponent<Moveable>().cam.gameObject.GetComponent<AudioListener>().enabled = true;
            hit.transform.gameObject.GetComponent<Moveable>().cam.enabled = true;
            //TODO: Hit Sound
            Drag(hit);

        }
        else
        {
            //TODO: Miss sound
            isGrappling = false;
            StopGrapple();
        }
    }

    private void Drag(RaycastHit hit)
    {
        grappleObject = hit.transform.gameObject;
        if (!sphere.GetComponent<Dragging>())
        {
            lr.positionCount = 2;

            drag = sphere.gameObject.AddComponent<Dragging>();
            drag.objectAttachedTo = grappleObject;
            drag.pullSpeed = pullSpeed;
            drag.distance = Vector3.Distance(grappleObject.transform.position, transform.position);
            drag.cam = myCam.gameObject;
        }
    }

    /*private void Hook(RaycastHit hit)
    {
        grappleObject = hit.transform.gameObject;
        if (!sphere.GetComponent<SpringJoint>())
        {
            joint = sphere.AddComponent<SpringJoint>();
        }
        joint.autoConfigureConnectedAnchor = false;
        joint.connectedAnchor = grappleObject.transform.position;

        float distanceFromPoint = Vector3.Distance(sphere.transform.position, grappleObject.transform.position);

        joint.maxDistance = distanceFromPoint * 0.8f;
        joint.minDistance = distanceFromPoint * 0.25f;

        //change these values
        joint.spring = 4.5f;
        joint.damper = 7f;
        joint.massScale = 4.5f;

        lr.positionCount = 2;
    }
*/
    void DrawRope()
    {
        ballTip = new Vector3(sphere.transform.position.x - 0.5f, sphere.transform.position.y, sphere.transform.position.z);
        if (!joint&&!drag) return;
        lr.SetPosition(0, ballTip);
        lr.SetPosition(1, grappleObject.transform.position);
    }

    void StopGrapple()
    {
        //TODO Let go sound
        lr.positionCount = 0;
        //Destroy(joint);
        Destroy(drag);
    }
}


