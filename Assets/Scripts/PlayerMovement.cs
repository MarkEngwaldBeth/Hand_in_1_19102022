using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb3d;
    private float jumpForce;
    private float moveSpeed;
    private bool isJumping;
    private bool jumpPressed;
    private float horizontalInput;

    // Start is called before the first frame update
    void Start()
    {
        rb3d = GetComponent<Rigidbody>();
        moveSpeed = 1.0f;
        jumpForce = 20.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Space key down");
            jumpPressed = true;
        }
        horizontalInput = Input.GetAxis("Horizontal");
    }
    private void FixedUpdate()
    {
            //rb3d.velocity = new Vector3(horizontalInput, rb3d.velocity.y , 0);
                    if(horizontalInput > 0.1f || horizontalInput < -0.1f)
        {
            rb3d.AddForce(new Vector2(horizontalInput * moveSpeed, 0f), ForceMode.Impulse);
        }


            if(isJumping)
            {
                return;
            }

            if (jumpPressed)
            {
                rb3d.AddForce(new Vector3(0f, jumpForce, 0f), ForceMode.Impulse);
                jumpPressed = false;
            }

            
    }   
    private void OnCollisionEnter(Collision collision)
    {
        isJumping = false;
    }
    private void OnCollisionExit(Collision collision)
    {
        isJumping = true;
    }
}
