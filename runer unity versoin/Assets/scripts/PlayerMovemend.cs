using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovemend : MonoBehaviour
{

    Rigidbody rb;
    public float forwardForce = 2000f;
    public float sidewaysForse = 500f;
    public KeyCode ToTheRight = KeyCode.D;
    public KeyCode ToTheLeft = KeyCode.A;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);
        if (Input.GetKey(ToTheRight))
        {
            rb.AddForce(sidewaysForse * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if (Input.GetKey(ToTheLeft))
        {
            rb.AddForce(-sidewaysForse * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if (rb.position.y <= 0.9)
        {
            GetComponent<PlayerMovemend>().enabled = false;
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
