using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarianMovement : MonoBehaviour
{
    public Follow controller;
    public Animator animator;

    //bool jump =false;

    // Update is called once per frame
    void Update()
    {

        animator.SetBool("isMoving",controller.ismoving);

    }


}
