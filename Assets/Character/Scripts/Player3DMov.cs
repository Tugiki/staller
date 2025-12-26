using UnityEngine;

public class Player3DMov : MonoBehaviour
{

    private float speed = 1f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.forward * z + transform.right * x;
        transform.position += move * speed * Time.deltaTime;
    }
}
