using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    float horizontal = 0f;
    float vertical = 0f;
    float speed = 30f;
    float jumpForce = 120f;

    Vector3 movement = Vector3.zero;
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        movement = transform.forward * vertical + transform.right * horizontal;
        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
        Debug.Log(rb.velocity);
    }

    private void FixedUpdate()
    {
        rb.AddForce(movement.normalized * speed, ForceMode.Acceleration);
    }
}
