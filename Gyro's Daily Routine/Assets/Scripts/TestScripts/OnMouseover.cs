using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnMouseover : MonoBehaviour
{
    static public bool mouseOverTiles = false;

    private void OnMouseOver()
    {
        mouseOverTiles = true;
    }

    private void OnMouseExit()
    {
        mouseOverTiles = false;
    }
}
