using UnityEngine;
//using UnityEngine.EventSystems;

public class Grappler : MonoBehaviour
{
    public float grappleSpeed;

    private Vector3 mousePos;
    private Camera _camera;

    public DistanceJoint2D distanceJoint;
    private LineRenderer lineRenderer;

    private Vector3 tempPos;

    private bool checkGrappling;
    public bool GrappleControl;
    public bool breakHook;

    // Start is called before the first frame update
    void Start()
    {
        _camera = Camera.main;
        distanceJoint = GetComponent<DistanceJoint2D>();
        lineRenderer = GetComponent<LineRenderer>();
        distanceJoint.enabled = false;
        checkGrappling = true;
        lineRenderer.positionCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        DrawLine();
        GetMousePos();
        GrappleLength();
        BreakHook();
        GrappleController();
        DestroyThisOnLevelEnd();
        CheckMouseButton();
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
        if (Input.GetKey(KeyCode.W) && GrappleControl)
        {
            distanceJoint.distance -= grappleSpeed * Time.deltaTime;
        }
        //if (Input.GetKey(KeyCode.S))
        //{
        //    distanceJoint.distance += grappleSpeed * Time.deltaTime;
        //}
    }

    private void BreakHook()
    {
        if (distanceJoint.distance <= 0.0051f && breakHook)
        {
            distanceJoint.enabled = false;
            lineRenderer.positionCount = 0;
        }
    }

    private void GrappleController()
    {
        if (!GrappleControl)
        {
            distanceJoint.distance -= grappleSpeed * Time.deltaTime;
        }
    }

    private void DestroyThisOnLevelEnd()
    {
        if (PlayerMovementBrian.gameStillRunning == false)
        {
            Destroy(this);
        }
    }

    private void CheckMouseButton()
    {
        if (Input.GetMouseButtonDown(0) && checkGrappling && PlayerMovementBrian.onGround/* && OnMouseover.mouseOverTiles*/)
        {
            distanceJoint.enabled = true;
            distanceJoint.connectedAnchor = mousePos;
            lineRenderer.positionCount = 2;
            tempPos = mousePos;
            checkGrappling = false;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            distanceJoint.enabled = false;
            checkGrappling = true;
            lineRenderer.positionCount = 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("death"))
        {
            distanceJoint.enabled = false;
            lineRenderer.positionCount = 0;
        }
    }
}
