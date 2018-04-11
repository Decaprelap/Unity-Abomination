using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public float panSpeed = 40.0f;
	public float panPadding = 10.0f;
	public float xPanMin = 20.0f;
	public float xPanMax = 20.0f;
	public float zPanMin = 20.0f;
	public float zPanMax = 20.0f;

	public float scrollSpeed = 20f;
	public float scrollMin = -160f;
	public float scrollMax = 160f;

	public Vector3 pos;

	private bool panLeft;
	private bool panRight;
	private bool panUp;
	private bool panDown;

	void LateUpdate () {
		// Diagonal moves faster so hit up stack overflow
		pos = transform.position;

		panLeft = false;
		panRight = false;
		panUp = false;
		panDown = false;

		if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panPadding) { panUp = true; pos.z += panSpeed * Time.deltaTime; }
		if (Input.GetKey("s") || Input.mousePosition.y <= panPadding) { panDown = true; pos.z -= panSpeed * Time.deltaTime; }
		if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panPadding) { panRight = true; pos.x += panSpeed * Time.deltaTime; }
		if (Input.GetKey("a") || Input.mousePosition.x <= panPadding) { panLeft = true; pos.x -= panSpeed * Time.deltaTime; }
		//Debug.Log ("CameraFollow Pos: " + pos);

		float scroll = Input.GetAxis ("Mouse ScrollWheel");

		float scrollMinRange = -pos.y + zPanMin ;
		float scrollMaxRange = -pos.y + zPanMax ;

		pos.x = Mathf.Clamp (pos.x, xPanMin, xPanMax);
		pos.z = Mathf.Clamp (pos.z, scrollMinRange, scrollMaxRange);

		transform.position = pos;
		transform.position += GameObject.Find("PlayerView").GetComponent<Camera>().transform.forward * Time.deltaTime * scroll * scrollSpeed;

		// When at max zoom
		if (pos.y >= scrollMax) { 
			if (!panLeft && !panRight && pos.x != 0) { pos.x = 0; }
			if (!panUp && !panDown && pos.z != scrollMin) { pos.z = scrollMin; }
			pos.y = scrollMax; 
			transform.position = pos;
			transform.position += GameObject.Find("PlayerView").GetComponent<Camera>().transform.forward * Time.deltaTime * scroll * scrollSpeed;
		}
		// When at min zoom
		//if (pos.y <= scrollMin) { 
		//	pos.y = scrollMin; 
		//	transform.position = pos;
		//	transform.position += GameObject.Find("PlayerView").GetComponent<Camera>().transform.forward * Time.deltaTime * scroll * scrollSpeed;
		//}

		if (pos.z >= scrollMax + zPanMax) { pos.z = scrollMax; transform.position = pos; }
		if (!panDown && pos.z <= scrollMin - zPanMax) { pos.z = scrollMin; transform.position = pos; }
	}
}
