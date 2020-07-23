using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grappler : MonoBehaviour
{
    public float grappleSpeed;

    private Vector3 mousePos;
    private Camera _camera;

    private bool check;

    public DistanceJoint2D distanceJoint;

    private LineRenderer lineRenderer;

    private Vector3 tempPos;

    public bool changeMode;

    
    // Start is called before the first frame update
    void Start()
    {
        _camera = Camera.main;
        distanceJoint = GetComponent<DistanceJoint2D>();
        lineRenderer = GetComponent<LineRenderer>();
        distanceJoint.enabled = false;
        check = true;
        lineRenderer.positionCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        GetMousePos();
        
        if (Input.GetMouseButtonDown(0) && check && PlayerMovementBrian.onGround)
        {
            distanceJoint.enabled = true;
            distanceJoint.connectedAnchor = mousePos;
            lineRenderer.positionCount = 2;
            tempPos = mousePos;
            check = false;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            distanceJoint.enabled = false;
            check = true;
            lineRenderer.positionCount = 0;
        }
        
        DrawLine();
        GrappleLength();

        if (changeMode)
        {
            distanceJoint.distance -= grappleSpeed * Time.deltaTime;
        }
    }

    private void DrawLine()
    {
        if (lineRenderer.positionCount <= 0) return;
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, tempPos);
    }

    private void GetMousePos()
    {
        mousePos = _camera.ScreenToWorldPoint(Input.mousePosition);
    }

    private void GrappleLength()
    {
        if (Input.GetKey(KeyCode.W) && !changeMode)
        {
            distanceJoint.distance -= grappleSpeed * Time.deltaTime;
        }
        //if (Input.GetKey(KeyCode.S))
        //{
        //    distanceJoint.distance += grappleSpeed * Time.deltaTime;
        //}
    }
}
