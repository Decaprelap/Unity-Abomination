using UnityEngine;

public class FaceMouse : MonoBehaviour {

    public Camera cam;
    public Vector3 MouseRayPosition;
    public GameObject player;
    private float distance;

	void Update () {
        // Shoot a ray from mouse position
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        // Create a plane across Y = 0 to collide with
        Plane hPlane = new Plane(Vector3.up, Vector3.zero);

        // Get point at Y = 0 where ray collides
        if (hPlane.Raycast(ray, out distance))
            MouseRayPosition = ray.GetPoint(distance);
      
        // Make sure the player looks parallel to ground
        MouseRayPosition.y = player.transform.position.y;

        // Look at Y intersect
        player.transform.LookAt(MouseRayPosition);
    }
}
