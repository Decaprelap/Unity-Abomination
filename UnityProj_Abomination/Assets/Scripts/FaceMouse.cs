using UnityEngine;
using UnityEngine.SceneManagement;

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

		// Perform this code if there is no active character eg.Bulding
		if (player == null) {
			if (Input.GetMouseButtonDown(0)) 
			{ 
				GameObject.Find("CameraStuff/CameraFollow").transform.position =  MouseRayPosition; 
				Debug.Log ("Click");
			
		
			}
		return;
		}

		// Perform this code if there is an active character eg.Raiding
		if (player.transform != null) {
			// Make sure the player looks parallel to ground
			MouseRayPosition.y = player.transform.position.y;
			Debug.Log ("Mainscene");

			// Look at Y intersect
			player.transform.LookAt(MouseRayPosition);
		}
	}
}
