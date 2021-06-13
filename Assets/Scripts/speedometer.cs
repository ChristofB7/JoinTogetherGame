using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class speedometer : MonoBehaviour
{

    private Rigidbody car;
    public TextMeshProUGUI carVelocity;
    public Rigidbody ball;
    public TextMeshProUGUI ballVelocity;
    // Start is called before the first frame update
    void Start()
    {
        car = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (ball.GetComponent<Dragging>()!=null)
        {
            car = ball.GetComponent<Dragging>().objectAttachedTo.GetComponent<Rigidbody>();
            carVelocity.text = Mathf.Round(Mathf.Abs(car.velocity.magnitude)).ToString();
        }
        else
        {
            carVelocity.text = "0";
        }


        ballVelocity.text = Mathf.Round(Mathf.Abs(ball.velocity.magnitude)).ToString();
    }
}
