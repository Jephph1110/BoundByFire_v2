using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    public float runSpeed = 40f;
    public float horizontalMove =0f;  
    public bool frozen = false;

    bool jump = false;

    // Update is called once per frame
    void Update()
    {
        if (!frozen)
        {
            horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

            animator.SetFloat("Speed",Mathf.Abs(horizontalMove));

            if(Input.GetButtonDown("Jump"))
            {
                jump = true;
                animator.SetBool("IsJumping", true);
            }
        }
    }

    public void Freeze(bool freeze)
    {
        //Set all animator params to ensure the player stops running, jumping, etc and simply stands
        if (freeze)
        {
            horizontalMove = 0f;
        }

        frozen = freeze;
    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }

    void FixedUpdate() 
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump=false;

    }
}
