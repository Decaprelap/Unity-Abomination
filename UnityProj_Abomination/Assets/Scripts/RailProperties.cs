using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailProperties : MonoBehaviour {

	public float Lifetime = 2.0f;           //Time untill bullets clear
	public int Damage = 1;

	void Start () {
		Destroy(gameObject, Lifetime);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Hitbox"))
		{
			other.gameObject.GetComponent<EntityHealth>().health -= Damage;
			//			if (other.gameObject.GetComponent<EntityHealth> ().health <= 0)
			//			Select Sounds
			//			if (other.gameObject.CompareTag("Hitbox") && other.gameObject.layer != 13)
			//				FindObjectOfType<AudioManager>().Play("hitTarget");
			//			if (other.gameObject.layer == 13)
			//				FindObjectOfType<AudioManager>().Play("codHit");
		}
	}
}
