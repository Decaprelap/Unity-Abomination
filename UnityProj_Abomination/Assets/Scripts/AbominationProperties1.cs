using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbominationProperties1 : MonoBehaviour {

	// Settings
	public float speed = 1.0f;
	public float newPositionTime = 5.0f;

	public Transform target;

	//misc variables
	bool oneCall = true;
	float count = 0;

	void Update() {
		float step = speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards(transform.position, target.position, step);
	}
}