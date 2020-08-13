using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseDownForeground : MonoBehaviour
{
    static bool mouseDown = false;

    private void OnMouseDown()
    {
        mouseDown = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(mouseDown);
    }
}
