using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletProperties : MonoBehaviour {

	public float Lifetime = 1.6f;           //Time untill bullets clear
	public int Damage = 1;
	public int Penetration = 2;
	int _health;

    public float bulletMaxSpeed = 2850;
    public float AccelTime = 1f;
    private float bulletSpeed = 0;
    private float t = 0;

    void Start () {
		Destroy(gameObject, Lifetime);
	}

    private void FixedUpdate()
    {
        // Bullet acceleration
        t += 1 / AccelTime * Time.deltaTime;
        bulletSpeed = Mathf.Lerp(bulletMaxSpeed, bulletMaxSpeed/4f, t);
        // Move Bullet foward
        GetComponent<Rigidbody>().velocity = transform.forward * bulletSpeed * Time.deltaTime;
    }

    void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Hitbox"))
		{
			other.gameObject.GetComponent<EntityHealth>().health -= Damage;
			if (other.gameObject.GetComponent<EntityHealth> ().health <= 0)
				Penetration -= 1;
			if (other.gameObject.GetComponent<EntityHealth>().health >= 1)
				Penetration = 0;
//			//Select Sounds
//			if (other.gameObject.CompareTag("Hitbox") && other.gameObject.layer != 13)
//				FindObjectOfType<AudioManager>().Play("hitTarget");
//			if (other.gameObject.layer == 13)
//				FindObjectOfType<AudioManager>().Play("codHit");
			if (Penetration <= 0) {
				Destroy(gameObject);
			}
		}
		if (other.gameObject.CompareTag("Matter") || other.gameObject.CompareTag("Hazard"))
		{
//			FindObjectOfType<AudioManager>().Play("hitMatter");
			Destroy(gameObject);
		}
	}
}
