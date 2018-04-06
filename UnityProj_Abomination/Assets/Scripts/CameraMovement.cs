using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public Transform target;

    public float smoothTime = 0.05f;
    public Vector3 viewOffset;
    private Vector3 velocity = Vector3.zero;

    private void Start()
    {
        //Make camera change starting position, remove for interesting zoom out effect?
        transform.position = target.position + viewOffset; 
    }

    void LateUpdate()
    {
        Vector3 desiredPosition = target.position + viewOffset;
        transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothTime);
    }
}