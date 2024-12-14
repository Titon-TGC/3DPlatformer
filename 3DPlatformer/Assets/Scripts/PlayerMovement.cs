using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    public float defaultSpeed;
    public int jumpCount;
    public int currentJumpCount;

    public float jumpForce;

    public float groundDrag;
    public float dashSpeed;
    public bool dashing;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;

    public Transform orienation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        moveSpeed = defaultSpeed;
        currentJumpCount = jumpCount;
    }

    private void Update()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);
        if(Input.GetKeyDown(KeyCode.Space)  && currentJumpCount > 0)
            Jump();
        if (dashing)
            moveSpeed = dashSpeed;
        else
            moveSpeed = defaultSpeed;
        
        MyInput();
        SpeedControl();

        if (grounded)
        {
            rb.drag = groundDrag;
            currentJumpCount = jumpCount;
        }
        else
            rb.drag = 0;
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void MovePlayer()
    {
        moveDirection = orienation.forward * verticalInput + orienation.right * horizontalInput;

        rb.AddForce(moveDirection * moveSpeed * 10f, ForceMode.Force);
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if(flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    private void Jump()
    {
        currentJumpCount -= 1;
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

}