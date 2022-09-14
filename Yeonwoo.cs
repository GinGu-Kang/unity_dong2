using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Yeonwoo : MonoBehaviour

{
    Animator animator;
    private float Yeonspeed = 3f;
    Vector3 movement;
    float horizontalMove;
    Rigidbody2D rigdbody;
    float Yeondir =1;
    float Yeonscale = 4.0f;
    bool leftPressed;
    bool rightpressed;



    void Awake()
    {
        animator = GetComponent<Animator>();
        rigdbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            leftGetKeyDown();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            rightGetkeyDown();
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            leftGetKeyUp();
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            rightGetKeyUp();
        }
        
        AnimationUpdate();

    }
    public void leftGetKeyDown()
    {
        leftPressed = true;
    }
    public void rightGetkeyDown()
    {
        rightpressed = true;
    }
    public void leftGetKeyUp()
    {
        leftPressed = false;
    }
    public void rightGetKeyUp()
    {
        rightpressed = false;
    }
    void FixedUpdate()
    {
        Walk();
    }
    
    void Walk()
    {
        if (leftPressed && rightpressed)
            horizontalMove = 0;
        else if (rightpressed)
            horizontalMove = 1;
        else if (leftPressed)
            horizontalMove = -1;
        else
            horizontalMove = 0;
        movement.Set(horizontalMove, 0,0);
        movement = movement.normalized *  Yeonspeed * Time.deltaTime;
        if (horizontalMove==1 || horizontalMove == -1)
        {
            Yeondir = -horizontalMove;
        }
        rigdbody.MovePosition(transform.position + movement);
        transform.localScale = new Vector3(Yeondir * Yeonscale, Yeonscale, Yeonscale);
    }
    void AnimationUpdate()
    {
        if (horizontalMove == 0)
        {
            animator.SetBool("isWalking", false);
        }
        else
        {
            animator.SetBool("isWalking", true);
        }
    }
}

