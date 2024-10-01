using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;             // Speed at which player moves
    public float jumpForce = 7f;             // Increased force applied for jumping

    private Rigidbody rb;

    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;            // Prevent player rotation
    }

    void Update()
    {
        MovePlayer();                        // Call movement function
        Jump();                              // Call jump function
    }

    void MovePlayer()
    {
        float moveX = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;  // Get horizontal input
        float moveZ = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;    // Get vertical input

        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        rb.MovePosition(transform.position + move);                             // Move player based on input
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);             // Apply upward force for jump
            isGrounded = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if player is grounded when colliding with ground or platforms
        if (collision.collider.CompareTag("Ground") || collision.collider.CompareTag("Platform"))
        {
            isGrounded = true;
        }
    }
}
