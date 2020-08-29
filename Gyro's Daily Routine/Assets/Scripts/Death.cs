﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    //private bool death = false;
    public GameObject player;
    public float xPos;
    public float yPos;
 
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
            PlayerMovementBrian.gameStillRunning = true;
        }
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.transform.position = new Vector2(xPos, yPos);
        }
    }
}