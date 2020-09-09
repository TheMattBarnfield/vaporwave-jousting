using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 12f;
    private CharacterController controller;

    public float gravity = 9.81f;
    public float jumpStrength = 20f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    private Vector3 velocity;
    private bool isGrounded;

    
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded)
        {
            if (velocity.y < 0) {
                velocity.y = -2f;
            }

            if (Input.GetKeyDown("space"))
            {
                velocity.y = jumpStrength;
            }
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        velocity = transform.right * x * speed +
            transform.up * (velocity.y + -gravity * Time.deltaTime) +
            transform.forward * z * speed;

        controller.Move(velocity * Time.deltaTime);
    }
}
