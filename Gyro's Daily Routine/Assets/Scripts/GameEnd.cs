﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnd : MonoBehaviour
{
    public SpriteRenderer levelEnd;
    public bool fadeIn = false;
    public float transparency = 0f;

    // Start is called before the first frame update
    void Awake()
    {
        levelEnd.color = new Color(1f, 1f, 1f, transparency);
    }

    // Update is called once per frame
    void Update()
    {
        LevelEnd();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //PlayerMovementBrian.moveSpeed = 0;
            PlayerMovementBrian.gameStillRunning = false;
            Debug.Log("is touching door");
            fadeIn = true;
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerMovementBrian.gameStillRunning = true;
        }
    }

    public void LevelEnd()
    {
        if (fadeIn)
        {
            levelEnd.color = new Color(1f, 1f, 1f, transparency += 0.1f * Time.deltaTime);
        }
    }
}
