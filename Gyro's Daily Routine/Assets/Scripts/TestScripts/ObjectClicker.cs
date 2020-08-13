using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectClicker : MonoBehaviour
{
    bool Pressed = false;

    private void OnMouseDown()
    {
        Pressed = true;
    }

    private void OnMouseUp()
    {
        Pressed = false;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Pressed);
    }

}
