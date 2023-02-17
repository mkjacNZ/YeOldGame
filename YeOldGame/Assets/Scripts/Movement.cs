using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    float horizontal = 0f;
    float vertical = 0f;
    float speed = 30f;
    float jumpForce = 100f;
    public bool grounded = false;
    float rotationSpeed = 600f;
    bool backTiltBackwards = false;
    bool backTiltForwards = false;

    Vector3 movement = Vector3.zero;
    Vector3 backRotation = Vector3.zero;
    Rigidbody rb;
    Animator animator;
    CapsuleCollider cc;
    public Transform back;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        cc = GetComponent<CapsuleCollider>();
    }

    private void Update()
    {
        RaycastHit hit;
        grounded = Physics.Raycast(transform.position, Vector3.down, out hit, 1.1f);
        if (Physics.Raycast(transform.position, Vector3.down, 1.9f) && !grounded && rb.velocity.y < 0f)
        {
            animator.SetBool("approachingGround", true);
        }
        else
        {
            animator.SetBool("approachingGround", false);
            animator.SetBool("jumpPressed", false);
        }

        if (grounded)
        {
            animator.SetBool("grounded", true);
        }
        else
        {
            animator.SetBool("grounded", false);
        }

        if (hit.collider != null)
        {
            if (transform.position.y - hit.collider.transform.position.y <= 0.05f)
            {
                animator.SetBool("aboveGround", true);
            }
        }
        else
        {
            animator.SetBool("aboveGround", false);
        }

        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        movement = transform.forward * vertical + transform.right * horizontal;
        if (Input.GetButtonDown("Jump") && grounded)
        {
            animator.SetBool("jumpPressed", true);
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.E))
        {
            animator.enabled = false;
        }
        else
        {
            animator.enabled = true;
        }
        if (Input.GetKey(KeyCode.Q))
        {
            backTiltForwards = true;
        }
        else
        {
            backTiltForwards = false;
        }
        if (Input.GetKey(KeyCode.E))
        {
            backTiltBackwards = true;
        }
        else
        {
            backTiltBackwards = false;
        }
    }

    private void FixedUpdate()
    {
        rb.AddForce(movement.normalized * speed, ForceMode.Acceleration);
        if (backTiltForwards)
        {
            back.Rotate(new Vector3(0f, 0f, 0.1f) * rotationSpeed * Time.fixedDeltaTime);
        }
        if (backTiltBackwards)
        {
            back.Rotate(new Vector3(0f, 0f, -0.1f) * rotationSpeed * Time.fixedDeltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "moving")
        {
            transform.SetParent(collision.transform);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "moving")
        {
            transform.SetParent(null);
        }
    }
}
