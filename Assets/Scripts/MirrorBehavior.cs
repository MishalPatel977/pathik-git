using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class MirrorBehavior : MonoBehaviour
{
    private Rigidbody rb;
    public float moveSpeed = 2f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true; // Make the Rigidbody kinematic to prevent physics issues
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            rb.isKinematic = false; // Allow the mirror to move when hit by the player
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            rb.isKinematic = true; // Stop moving the mirror when the player stops colliding
        }
    }
}


