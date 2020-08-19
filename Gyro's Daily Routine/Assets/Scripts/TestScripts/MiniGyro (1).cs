using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGyro : MonoBehaviour
    
{
    Vector3 temp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H) == true)
        {
            temp = transform.localScale;

            temp.x = 0.75f;
            temp.y = 0.75f;
            temp.z = 0.75f;
            transform.localScale = temp;

        }
        else 
        {
            temp = transform.localScale;

            temp.x = 1.5f;
            temp.y = 1.5f;
            temp.z = 1.5f;
            transform.localScale = temp;
        }

    }
}
