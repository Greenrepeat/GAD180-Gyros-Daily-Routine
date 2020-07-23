using Boo.Lang.Environments;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementBrian : MonoBehaviour
{
    public float moveSpeed;
    public float jumpSpeed;
    private float horizontalInput;
    public static bool onGround;
    public bool grappleFromGroundOnly;

    Rigidbody2D myRigidbody2D;
    CapsuleCollider2D myBody;
    BoxCollider2D myFeet;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
        myBody = GetComponent<CapsuleCollider2D>();
        myFeet = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Run();
        Jump();
        FlipSprite();

        if (Input.GetMouseButtonDown(0))
        {
            this.transform.parent = null;
            myFeet.enabled = false;
        }
        if (Input.GetMouseButtonUp(0))
        {
            myFeet.enabled = true;
        }
        //while (Input.GetMouseButtonDown(0))
        //{
        //    Vector2 playerJitter = new Vector2(0.1f * moveSpeed, myRigidbody2D.velocity.y);
        //    myRigidbody2D.velocity = playerJitter;
        //}
    }

    private void Run()
    {
        float moveCharacter = Input.GetAxis("Horizontal");
        Vector2 playerVelocity = new Vector2(moveCharacter * moveSpeed, myRigidbody2D.velocity.y);
        myRigidbody2D.velocity = playerVelocity;
        //Debug.Log(playerVelocity);
    }

    private void Jump()
    {
        if (myFeet.IsTouchingLayers(LayerMask.GetMask("Foreground")))
        {
            if (Input.GetButtonDown("Jump"))
            {
                Vector2 jumpVelocity = new Vector2(0f, jumpSpeed);
                myRigidbody2D.velocity += jumpVelocity;
            }
            onGround = true;
        }

        if (!myFeet.IsTouchingLayers(LayerMask.GetMask("Foreground")) && grappleFromGroundOnly)
        {
            onGround = false;
        }

    }

    private void FlipSprite()
    {
        bool playerIsMoving = Mathf.Abs(myRigidbody2D.velocity.x) > Mathf.Epsilon;
        
        if (playerIsMoving)
        {
            transform.localScale = new Vector2(Mathf.Sign(myRigidbody2D.velocity.x), 1f);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("MovingPlatform"))
        {
            this.transform.parent = other.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("MovingPlatform"))
        {
            this.transform.parent = null;
        }
    }

}
