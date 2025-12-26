using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float moveSpeed = 1f;

    public Rigidbody rb;
    public Animator animator; 
    
    
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
        
        animator.SetFloat("Horizontal", x);
        animator.SetFloat("Vertical", z);
        

        Vector3 move = transform.forward * z + transform.right * x;
        transform.position += move * moveSpeed * Time.deltaTime;

        animator.SetFloat("Speed", move.sqrMagnitude);
    }

    void FixedUpdate()
    {

    }

}