﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {


    Rigidbody2D myRB;
    SpriteRenderer myRenderer;
    Animator myAnimator;

    //direction
    bool canMove = true;
    bool faceingRight = true;

    //move
    public float maxSpeed;
    public float minSpeed;

    //jump
    bool grounded = false;
    float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float jumpPower;


    // Use this for initialization
    void Start () {
        myRB = GetComponent<Rigidbody2D>();
        myRenderer = GetComponent<SpriteRenderer>();
        myAnimator = GetComponent<Animator>();

    }
	
	// Update is called once per frame
	void Update () {

        if((grounded)&&Input.GetAxis("Jump")>0)
        {
            myAnimator.SetBool("isGrounded", false);
            myRB.velocity = new Vector2(myRB.velocity.x, 0f);
            myRB.AddForce(new Vector2(0, jumpPower),ForceMode2D.Impulse);
            grounded = false;
        }

        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        myAnimator.SetBool("isGrounded", true);


        float move = Input.GetAxis("Horizontal");


        if ((move > 0) && (faceingRight == false))//pressing to right
        {
            Flip();
            faceingRight = true;
   
        }
        else if((move < 0) && (faceingRight == true))
        {
            Flip();
            faceingRight = false;
        }

        myRB.velocity = new Vector2(move * maxSpeed, myRB.velocity.y);
        myAnimator.SetFloat("MoveSpeed", Mathf.Abs(move));



    }




    void Flip()
    {
        if (faceingRight == true)
        {
            myRenderer.flipX = true;
        }
        if (faceingRight == false)
        {
            myRenderer.flipX = false;
        }
    }
}

