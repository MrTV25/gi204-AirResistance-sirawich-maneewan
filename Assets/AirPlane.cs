using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirPlane : MonoBehaviour
{
    private Rigidbody rb;
    public float enginePower = 50f;
    public float liftBooster = 0.5f;
    public float dragDamp = 0.03f;
    public float angularDragDamp = 0.03f;

    public float yawPower = 50.0f;
    public float pitchPower = 10.0f;
    public float rollPower = 10.0f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {//Thrust
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(transform.forward*enginePower);
        }
        //Lift
        Vector3 lift = Vector3.Project(rb.velocity, transform.forward);
        rb.AddForce(transform.up*lift.magnitude*liftBooster);

        //Drag
        rb.velocity -= rb.velocity * dragDamp;
        rb.angularVelocity -= rb.angularVelocity * angularDragDamp;
        // Control
        float yaw = Input.GetAxis("Horizontal")*yawPower;
        rb.AddTorque(transform.up * yaw);

        float pitch = Input.GetAxis("Vertical") * pitchPower;
        rb.AddTorque(-transform.right*pitch);

        float roll = Input.GetAxis("Roll") * rollPower;
        rb.AddTorque(-transform.forward*roll);
    }
}
