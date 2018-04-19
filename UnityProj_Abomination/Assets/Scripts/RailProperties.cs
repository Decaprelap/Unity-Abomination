using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailProperties : MonoBehaviour {

	public float Lifetime = 0.5f;           //Time untill bullets clear
	public int Damage = 1;

    private Vector3 initialScale;
    private Vector3 endScale;
    private float t;
    private bool dangerous = true;

    void Start() {
        Destroy(gameObject, Lifetime);
        initialScale = gameObject.transform.localScale;
        endScale = new Vector3(0,0,initialScale.z);
        t = 0f;
    }

    void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Hitbox") && dangerous)
		{
			other.gameObject.GetComponent<EntityHealth>().health -= Damage;
            //			if (other.gameObject.GetComponent<EntityHealth> ().health <= 0)
            //			Select Sounds
            //			if (other.gameObject.CompareTag("Hitbox") && other.gameObject.layer != 13)
            //				FindObjectOfType<AudioManager>().Play("hitTarget");
            //			if (other.gameObject.layer == 13)
            //				FindObjectOfType<AudioManager>().Play("codHit");
		}
        if (t > 0.2) { dangerous = false; }
	}

    void Update()
    {
        gameObject.transform.localScale = Vector3.Lerp(initialScale, endScale, t);
        t += 1 / Lifetime * Time.deltaTime;
        Debug.Log("t is: " + t);
    }
}
