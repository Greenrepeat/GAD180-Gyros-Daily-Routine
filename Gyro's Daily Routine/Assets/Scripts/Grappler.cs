using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grappler : MonoBehaviour
{
    public float grappleSpeed;

    private Vector3 _mousePos;
    private Camera _camera;

    private bool _check;

    public DistanceJoint2D _distanceJoint;

    private LineRenderer _lineRenderer;

    private Vector3 _tempPos;

    
    // Start is called before the first frame update
    void Start()
    {
        _camera = Camera.main;
        _distanceJoint = GetComponent<DistanceJoint2D>();
        _lineRenderer = GetComponent<LineRenderer>();
        _distanceJoint.enabled = false;
        _check = true;
        _lineRenderer.positionCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        GetMousePos();
        if (Input.GetMouseButtonDown(0) && _check && PlayerMovementBrian.onGround)
        {
            _distanceJoint.enabled = true;
            _distanceJoint.connectedAnchor = _mousePos;
            _lineRenderer.positionCount = 2;
            _tempPos = _mousePos;
            _check = false;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            _distanceJoint.enabled = false;
            _check = true;
            _lineRenderer.positionCount = 0;
        }
        DrawLine();

        GrappleLength();
    }

    private void DrawLine()
    {
        if (_lineRenderer.positionCount <= 0) return;
        _lineRenderer.SetPosition(0, transform.position);
        _lineRenderer.SetPosition(1, _tempPos);
    }

    private void GetMousePos()
    {
        _mousePos = _camera.ScreenToWorldPoint(Input.mousePosition);
    }

    private void GrappleLength()
    {
        if (Input.GetKey(KeyCode.W))
        {
            _distanceJoint.distance -= grappleSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            _distanceJoint.distance += grappleSpeed * Time.deltaTime;
        }
    }
}
