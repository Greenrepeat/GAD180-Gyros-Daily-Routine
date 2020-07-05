using Boo.Lang.Environments;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int moveSpeed;
    private float horizontalInput;

    Rigidbody2D myRigidbody2D;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();  
    }

    // Update is called once per frame
    void Update()
    {
        Run();
        FlipSprite();
        //Move();
    }

    private void Run()
    {
        float moveCharacter = Input.GetAxis("Horizontal");
        Vector2 playerVelocity = new Vector2(moveCharacter * moveSpeed, myRigidbody2D.velocity.y);
        myRigidbody2D.velocity = playerVelocity;
    }

    private void Move()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * Time.deltaTime * moveSpeed * horizontalInput);
    }

    private void FlipSprite()
    {
        bool playerIsMoving = Mathf.Abs(myRigidbody2D.velocity.x) > Mathf.Epsilon;
        
        if (playerIsMoving)
        {
            transform.localScale = new Vector2(Mathf.Sign(myRigidbody2D.velocity.x), 1f);
        }
    }
}
