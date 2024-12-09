using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private float yaw = 0.0f, pitch = 0.0f;
    private Rigidbody rb;
    public GameObject cam;

    private bool canJump;
    private bool isGrounded;

    [SerializeField] float walkSpeed = 5.0f, sensitivity = 2.0f, dashStrength = 1.0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rb = gameObject.GetComponent<Rigidbody>();
        canJump = true;
        isGrounded = true;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && canJump == true && isGrounded == true)
            rb.velocity = new Vector3(rb.velocity.x, 5.0f, rb.velocity.z);
        if (Input.GetKey(KeyCode.LeftShift))
            rb.velocity = new Vector3(rb.velocity.x, 1, rb.velocity.z) * dashStrength;
        Look();
    }

    private void FixedUpdate()
    {
        Movement();
    }

    void Look()
    {
        pitch -= Input.GetAxisRaw("Mouse Y") * sensitivity;
        pitch = Mathf.Clamp(pitch, -90.0f, 90.0f);
        yaw += Input.GetAxisRaw("Mouse X") * sensitivity;
        cam.transform.localRotation = Quaternion.Euler(pitch, yaw, 0);
    }

    void Movement()
    {
        Vector2 axis = new Vector2(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal")) * walkSpeed;
        Vector3 forward = new Vector3(-cam.transform.right.z, 0.0f, cam.transform.right.x);
        Vector3 wishDirection = (forward * axis.x + cam.transform.right * axis.y + Vector3.up * rb.velocity.y);
        rb.velocity = wishDirection;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            canJump = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}