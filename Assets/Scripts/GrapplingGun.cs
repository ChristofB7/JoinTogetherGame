using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingGun : MonoBehaviour
{
    private LineRenderer lr;
    public Transform ballTip;
    private Vector3 grapplePoint;
    public LayerMask grappleLayer;
    public Transform myCam;
    public float maxDistance = 100f;
    private SpringJoint joint;
    public GameObject sphere;

    private void Awake()
    {
        lr = GetComponent<LineRenderer>();
    }
    void Update()
    {
        float mwheel = Input.GetAxis("Mouse ScrollWheel");
        Debug.Log(mwheel);
        if (mwheel > 0 && joint)
        {
            joint.maxDistance *= 0.80f;
        }
        if(mwheel < 0 && joint)
        {
            joint.maxDistance *= 1.20f;
        }

        if (Input.GetMouseButton(0))
        {
            StartGrapple();

        }
        else if (Input.GetMouseButtonUp(0))
        {
            StopGrapple();
        }
    }

    private void LateUpdate()
    {
        DrawRope();
    }

    void StartGrapple()
    {
        RaycastHit hit;
        if(Physics.Raycast(myCam.position, myCam.forward, out hit, maxDistance, grappleLayer))
        {
            grapplePoint = hit.point;
            Debug.Log(hit.transform.gameObject.name);
            if (!sphere.GetComponent<SpringJoint>())
            {
                joint = sphere.AddComponent<SpringJoint>();
            }
            joint.autoConfigureConnectedAnchor = false;
            joint.connectedAnchor = grapplePoint;

            float distanceFromPoint = Vector3.Distance(sphere.transform.position, grapplePoint);

            joint.maxDistance = distanceFromPoint * 0.8f;
            joint.minDistance = distanceFromPoint * 0.25f;

            //change these values
            joint.spring = 4.5f;
            joint.damper = 7f;
            joint.massScale = 4.5f;

            lr.positionCount = 2;
        }
    }

    void DrawRope()
    {
        if (!joint) return;
        lr.SetPosition(0, ballTip.position);
        lr.SetPosition(1, grapplePoint);
    }

    void StopGrapple()
    {
        lr.positionCount = 0;
        Destroy(joint);
        Debug.Log(joint);
    }
}


