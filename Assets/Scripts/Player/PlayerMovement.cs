using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public PlayerController playerController;
    float HorizontalMove = 0f;
    public Animator anim;
    public float RunSpeed = 40f;
    bool jump;

    public Joystick joystick;

    [SerializeField] LayerMask GroundLayer;

    bool isGrounded = false;
    public Transform GroundCheckCollider;
    public float groundCheckRadius;

    void Update()
    {

<<<<<<< Updated upstream
        HorizontalMove = Input.GetAxisRaw("Horizontal") * RunSpeed;
=======
        if (canMove == true)
        {
            HorizontalMove = joystick.Horizontal * RunSpeed;
        }
>>>>>>> Stashed changes

        GroundCheck();

        if (!isGrounded)
        {
            anim.SetBool("isJumping", true);
        }
        else
        {
            anim.SetBool("isJumping", false);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {

            if (isGrounded)
            {
                jump = true;
                anim.SetBool("isJumping", true);
            }

        }
    }

    void FixedUpdate()
    {
        playerController.Move(HorizontalMove * Time.fixedDeltaTime, jump);
        jump = false;
    }

    void GroundCheck()
    {
        isGrounded = false;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(GroundCheckCollider.position, groundCheckRadius, GroundLayer);

        if (colliders.Length > 0)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }
}
