using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour {
    public Rigidbody sphere;

    public float forwardAccel = 8f, reverseAccel = 4f, maxSpeed = 50f, turnStrength = 180f, gravityForce = 10f, dragOnGround = 3f;

    public Transform LFWheel, RFWheel;
    public float maxWheelTurn = 25f;

    private bool grounded;

    public LayerMask ground;
    public float groundRayLength = 0.5f;
    public Transform groundRayPoint;

    public ParticleSystem[] dustTrail;
    public float maxEmission = 25f;
    private float emissionRate;

    private float speedInput, turnInput;
    private Vector3 offset;

    public Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        sphere.transform.parent = null;
        offset = new Vector3(0f, -1.15f, 0f);
    }

    // Update is called once per frame
    void Update()
    {

            getInput();

    }

    float getCamEnabled()
    {
        if (cam.enabled)
        {
            return 1f;
        }
        else
        {
            return 0f;
        }
    }

    private void getInput()
    {
        speedInput = 0f;
        if (Input.GetAxis("Vertical") > 0)
        {
            speedInput = Input.GetAxis("Vertical") * forwardAccel * 1000f;
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            speedInput = Input.GetAxis("Vertical") * reverseAccel * 1000f;
        }

        turnInput = Input.GetAxis("Horizontal");
        if (grounded)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0f, turnInput * turnStrength * Time.deltaTime * Input.GetAxis("Vertical")*getCamEnabled(), 0f));
        }

        LFWheel.localRotation = Quaternion.Euler(LFWheel.localRotation.eulerAngles.x, (turnInput * maxWheelTurn) - 180, LFWheel.localRotation.eulerAngles.z);
        RFWheel.localRotation = Quaternion.Euler(RFWheel.localRotation.eulerAngles.x, turnInput * maxWheelTurn, RFWheel.localRotation.eulerAngles.z);


        transform.position = sphere.transform.position + offset;
    }

    void FixedUpdate()
    {
        emissionRate = 0;

        grounded = false;
        RaycastHit hit;

        if (Physics.Raycast(groundRayPoint.position, -transform.up, out hit, groundRayLength, ground))
        {
            grounded = true;

            transform.rotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;
        }



        if (grounded && cam.enabled)
        {
            sphere.drag = dragOnGround;
            if (Mathf.Abs(speedInput) > 0)
            {
                sphere.AddForce(transform.forward * speedInput);
                emissionRate = maxEmission;
            }
        }
        else
        {
            sphere.drag = 0.1f;
            sphere.AddForce(Vector3.up * -gravityForce * 100f);
        }

        foreach (ParticleSystem part in dustTrail)
        {
            var emissionModule = part.emission;
            emissionModule.rateOverTime = emissionRate;
        }

    }
}
