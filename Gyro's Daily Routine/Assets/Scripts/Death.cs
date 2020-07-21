using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    //private bool death = false;

    public GameObject player;
 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.transform.position = new Vector2(0.5f, 0.5f);
            //SceneManager.LoadScene(0);
            //death = true;
            //Debug.Log(death);
        }
    }
}
