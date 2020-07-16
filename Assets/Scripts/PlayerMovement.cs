using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float forwardForce = 10.0f;
    public float sideForce = 10.0f;
    private Rigidbody rb;
    private bool onRight;
    private bool onLeft;

    private Vector3 pvel;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        onRight = Input.GetKey("d");
        onLeft = Input.GetKey("a");
    }

    void FixedUpdate()
    {
        rb.AddForce(Vector3.forward * forwardForce * Time.deltaTime - rb.velocity); //a trick to make speed somewhat constant
        pvel = rb.velocity;

        if(onRight)
        {
            rb.AddForce(sideForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if(onLeft)
        {
            rb.AddForce(-sideForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
    }

    public Rigidbody GetRigidbody()
    {
        return rb;
    }
}
