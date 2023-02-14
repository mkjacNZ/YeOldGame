using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    float horizontal = 0f;
    float vertical = 0f;
    float speed = 10f;

    public Mesh legs;
    public Mesh torso;
    Mesh bodyMesh;
    MeshFilter mf;
    MeshCollider mc;
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        rb.velocity = (transform.forward * vertical + transform.right * horizontal) * speed;
    }
}
