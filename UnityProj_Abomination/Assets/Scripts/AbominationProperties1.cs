using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbominationProperties1 : MonoBehaviour {

	// Settings
	public float speed = 1.0f;
	public float newPositionTime = 5.0f;

	void Update() {
        if (GameObject.Find("Player").transform.position == null)
        {
            Debug.Log("No target for Abominations");
            return;
        }
        if (GameObject.Find("Player").transform.position != null)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, GameObject.Find("Player").transform.position, step);
        }
	}
}