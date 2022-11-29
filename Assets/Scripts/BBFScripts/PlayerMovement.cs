using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public CapsuleCollider2D capsuleCollider;
    public Animator animator;
    public float runSpeed = 40f;
    float horizontalMove =0f;  
    bool jump =false;

    private Vector2 movementInput = Vector2.zero;
    private bool jumpedInput = false;
    [SerializeField] private LayerMask platformLayerMask;

    //[SerializeField] InputActionReference jumping;

///////////////////////////////////////
    public void OnMove(Vector2 context)
    {
        movementInput = context;

    }
    public void OnJump(bool context)
    {
        //jumped = context.ReadValue<bool>();
        jumpedInput = context;

    }
///////////////////////////////////////

     void Start() {
    {
        capsuleCollider = GetComponent<CapsuleCollider2D>();

    }
}

    // Update is called once per frame
    void Update()
    {
        horizontalMove = movementInput.x * runSpeed;

        animator.SetFloat("Speed",Mathf.Abs(horizontalMove));

        if(jumpedInput && isGrounded())
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        }
    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }

    void FixedUpdate() 
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump=false;
        jumpedInput=false;
    }

    private bool isGrounded()    //extra load bearing code
    {
        float extraHeightText = 1f;
        RaycastHit2D raycastHit = Physics2D.Raycast(capsuleCollider.bounds.center, Vector2.down, capsuleCollider.bounds.extents.y + extraHeightText, platformLayerMask);

        Color rayColor;
        if(raycastHit.collider != null)
            rayColor = Color.green;
        else
        rayColor=Color.red;
        Debug.DrawRay(capsuleCollider.bounds.center, Vector2.down * (capsuleCollider.bounds.extents.y + extraHeightText));


        return raycastHit.collider != null;
    }
}
