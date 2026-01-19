using System.Security.Cryptography;
using UnityEngine;

public class Player3DMov : MonoBehaviour
{
    [Header("References")]
    private CharacterController controller;
    [SerializeField] private Transform   camera;


    [Header("Movement Settings")]
    [SerializeField] private float walkSpeed = 1f;
    [SerializeField] private float turningSpeed = 4f;
    [SerializeField] private float jumpHeight = 0.1f;


    [SerializeField] private float gravity = 9.81f;

    private float verticalVelocity;
    private Animator animator;

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
        move = transform.TransformDirection(move);

        move.y = VerticalForceCalculation();

        move *= walkSpeed;

        controller.Move(move * Time.deltaTime);
    }

    private void Movement()
    {
        GroundMovement();
        Turn();
        Player2DAnimation();
    }

    private float VerticalForceCalculation()
    {
        if (controller.isGrounded)
        {
            verticalVelocity = -1f; // Small negative value to keep the player grounded

            if (Input.GetButtonDown("Jump"))
            {
                verticalVelocity = Mathf.Sqrt(jumpHeight * 2 * gravity);
            }

        } else
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }
        return verticalVelocity;
    }
    private void Player2DAnimation()
    {

        animator.SetBool("isWalking", true);

        if (moveInput == 0 && turnInput == 0)
        {
            animator.SetBool("isWalking", false);
            animator.SetFloat("LastInputX", 0);
            animator.SetFloat("LastInputY", 1);
        }

        animator.SetFloat("InputX", turnInput);
        animator.SetFloat("InputY", -(moveInput));
    }
    private void Turn()
    {

        if(true)
        {
            Vector3 currentLookDirection = camera.forward;
            currentLookDirection.y = 0;

            Quaternion targetRotation = Quaternion.LookRotation(currentLookDirection);
            transform.rotation = targetRotation;
             
        }
        
    }
    private void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        InputManagement();
        Movement();
    }

    
}
