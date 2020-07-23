using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformBrian : MonoBehaviour
{
    public Vector3 position1;
    public Vector3 position2;
    public float speed = 1;

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(position1, position2, Mathf.PingPong(Time.time * speed, 1.0f));

        //if (Input.GetMouseButtonDown(0))
        //{
        //    this.GetComponent<BoxCollider2D>().enabled = false;
        //}
        
        //if (Input.GetMouseButtonUp(0))
        //{
        //    this.GetComponent<BoxCollider2D>().enabled = true;
        //}
    }
}
