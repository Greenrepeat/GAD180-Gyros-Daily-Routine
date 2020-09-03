//using UnityEditor.Compilation;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovementBrian : MonoBehaviour
{
    public static float moveSpeed = 5f;
    public float jumpSpeed;
    [HideInInspector] public static bool onGround;
    public bool grappleFromGroundOnly;
    public static bool gameStillRunning = true;

    private Rigidbody2D myRigidbody2D;
    private BoxCollider2D myFeet;

    private bool onPlatform;

    public float burstSpeedDuration = 30f;

    public static bool isDashing = false;


    public AudioClip wheels;

    AudioSource audioSource;

    public UnityEvent JumpEvent;

    //public static bool isGrappling;


    Vector3 tempSize;
    // Start is called before the first frame update
    void Start()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
        myFeet = GetComponent<BoxCollider2D>();
        audioSource = GetComponent<AudioSource>();

        onPlatform = false;

   
    }

    // Update is called once per frame
    void Update()
    {
        Run();
        Jump();
        FlipSprite();
        DisableThisOnGameEnd();
        StartCoroutine(flashyBoots());
        //CheckMouseButton();

        if (Input.GetMouseButtonDown(0) && onPlatform)
        {
            Vector2 jumpVelocity = new Vector2(0f, jumpSpeed * 2);
            myRigidbody2D.velocity += jumpVelocity;
        }

        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
        //Debug.Log(onPlatform);
    }

    private void Run()
    {
        float moveCharacter = Input.GetAxis("Horizontal");
        Vector2 playerVelocity = new Vector2(moveCharacter * moveSpeed, myRigidbody2D.velocity.y);
        myRigidbody2D.velocity = playerVelocity;


        //float h = Input.GetAxis("Horizontal");

        //Vector3 tempVect = new Vector3(x: h, y: 0, z: 0);
        //tempVect = tempVect.normalized * (moveSpeed * Time.deltaTime);
        //transform.position += tempVect


        //Debug.Log(playerVelocity);

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            if(myFeet.IsTouchingLayers(LayerMask.GetMask("Foreground")))
            {
                if (!audioSource.isPlaying)
                {
                    audioSource.Play();
                }

            }
        }

        if (Input.GetKey(KeyCode.Space))
        {
            audioSource.Stop();
        }
    }

    private void Jump()
    {
        if (myFeet.IsTouchingLayers(LayerMask.GetMask("Foreground")))
        {
            if (Input.GetButtonDown("Jump"))
            {
                Vector2 jumpVelocity = new Vector2(0f, jumpSpeed);
                myRigidbody2D.velocity += jumpVelocity;
                JumpEvent.Invoke();
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

    IEnumerator flashyBoots()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && !isDashing)
        {
            moveSpeed *= 2.2f;
            audioSource.pitch *= 2f;
            isDashing = true;
            yield return new WaitForSeconds(burstSpeedDuration);
            moveSpeed /= 2.2f;
            audioSource.pitch /= 2f;
            yield return new WaitForSeconds(burstSpeedDuration * 2);
            isDashing = false;
        }
    }

    

    //private void CheckMouseButton()
    //{
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        this.transform.parent = null;
    //        myFeet.enabled = false;
    //    }
    //    else if (Input.GetMouseButtonUp(0))
    //    {
    //        myFeet.enabled = true;
    //    }
    //}

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("MovingPlatform"))
        {
            onPlatform = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("MovingPlatform"))
        {
            onPlatform = false;
        }
    }

}
