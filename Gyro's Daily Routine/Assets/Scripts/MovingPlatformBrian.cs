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
    }
}
