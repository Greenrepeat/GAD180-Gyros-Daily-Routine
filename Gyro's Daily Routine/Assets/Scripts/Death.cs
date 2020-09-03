using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class Death : MonoBehaviour
{
    //private bool death = false;
    public GameObject player;
    public float xPos;
    public float yPos;

    public GameObject blood;

    public UnityEvent deathSound;
 
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKey("escape"))
        //{
        //    Application.Quit();
        //}
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(PlayerDeath());

            //player.transform.position = new Vector2(xPos, yPos);
        }
    }

    IEnumerator PlayerDeath()
    {
        Instantiate(blood, player.transform.position, Quaternion.identity);
        player.SetActive(false);
        yield return new WaitForSeconds(1.5f);
        player.SetActive(true);
        player.transform.position = new Vector2(xPos, yPos);
        PlayerMovementBrian.isDashing = false;
        PlayerMovementBrian.moveSpeed = 5f;
    }
}
