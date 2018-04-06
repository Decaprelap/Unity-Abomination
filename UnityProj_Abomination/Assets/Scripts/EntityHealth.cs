using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityHealth : MonoBehaviour {

	public int health = 1;

	void Update () {
		if (health <= 0)
		{
				Destroy(gameObject, 0.0f);
		}
	}
}
