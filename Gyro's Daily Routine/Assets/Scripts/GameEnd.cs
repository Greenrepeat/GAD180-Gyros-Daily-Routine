using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class GameEnd : MonoBehaviour
{
    //public SpriteRenderer levelEnd;
    public bool fadeIn = false;
    public float transparency = 0f;

    public int sceneNumber;

    // Start is called before the first frame update
    void Awake()
    {
        //levelEnd.color = new Color(1f, 1f, 1f, transparency);
    }

    // Update is called once per frame
    void Update()
    {
        LevelEnd();
    }

    public void LevelEnd()
    {
        if (fadeIn)
        {
            //levelEnd.color = new Color(1f, 1f, 1f, transparency += 0.1f * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerMovementBrian.moveSpeed = 5f;
            PlayerMovementBrian.isDashing = false;
            SceneManager.LoadScene(sceneNumber);
            
            //PlayerMovementBrian.gameStillRunning = false;
            fadeIn = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //PlayerMovementBrian.gameStillRunning = true;
        }
    }

}
