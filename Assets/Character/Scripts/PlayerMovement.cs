using System.Security.Cryptography;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("References")]
    private CharacterController controller;

    [Header("Movement Settings")]
    [SerializeField] private float walkSpeed = 1f;


    [SerializeField] private float gravity = 9.81f;

    private float verticalVelocity;

    [Header("Input")]
    private float moveInput;
    private float turnInput;

    private void InputManagement()
    {
        moveInput = Input.GetAxis("Vertical");
        turnInput = Input.GetAxis("Horizontal");


    }

    private void GroundMovement()
    {
        Vector3 move = new Vector3(turnInput, 0, moveInput);

        move.y = VerticalForceCalculation();

        move *= walkSpeed;

        controller.Move(move * Time.deltaTime);
    }

    private void Movement()
    {
        GroundMovement();
    }

    private float VerticalForceCalculation()
    {
        if (controller.isGrounded)
        {
            verticalVelocity = -1f; // Small negative value to keep the player grounded
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }
        return verticalVelocity;
    }

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        InputManagement();
        Movement();
    }


}