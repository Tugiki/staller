using UnityEngine;

public class Player3DMov : MonoBehaviour
{
    [Header("References")]
    private CharacterController controller;

    [Header("Movement Settings")]
    [SerializeField] private float walkSpeed = 2f;

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

        move.y = 0;

        move *= walkSpeed;

        controller.Move(move * Time.deltaTime);
    }

    private void Movement()
    {
        GroundMovement();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    private void Update()
    {
        InputManagement();
        Movement();
    }

    
}
