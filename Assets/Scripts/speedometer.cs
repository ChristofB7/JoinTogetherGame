using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class speedometer : MonoBehaviour
{

    public Rigidbody car;
    public TextMeshProUGUI carVelocity;
    public Rigidbody ball;
    public TextMeshProUGUI ballVelocity;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        carVelocity.text = Mathf.Round(Mathf.Abs(car.velocity.x)).ToString();
        ballVelocity.text = Mathf.Round(Mathf.Abs(ball.velocity.x)).ToString();
    }
}
