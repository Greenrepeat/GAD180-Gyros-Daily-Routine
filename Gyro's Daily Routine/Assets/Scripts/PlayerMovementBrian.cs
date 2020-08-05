using UnityEngine;

public class PlayerMovementBrian : MonoBehaviour
{
    public static float moveSpeed = 5f;
    public float jumpSpeed;
    public static bool onGround;
    public bool grappleFromGroundOnly;
    public static bool gameStillRunning = true;

    Rigidbody2D myRigidbody2D;
    BoxCollider2D myFeet;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
        myFeet = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Run();
        Jump();
        FlipSprite();
        CheckMouseButton();
        DisableThisOnGameEnd();
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

    private void CheckMouseButton()
    {
        if (Input.GetMouseButtonDown(0))
        {
            this.transform.parent = null;
            myFeet.enabled = false;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            myFeet.enabled = true;
        }
    }

    private void DisableThisOnGameEnd()
    {
        if (gameStillRunning)
        {
            this.enabled = true;
        }
        else if (!gameStillRunning)
        {
            this.enabled = false;
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
