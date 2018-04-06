using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEmitter : MonoBehaviour {
    public Transform bulletEmit;
    public GameObject bulletGfx;
	public GameObject RailGfx;

    public float bulletSpeed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0)){
            GameObject activeBullet = Instantiate(bulletGfx, bulletEmit.position, bulletEmit.rotation);
            activeBullet.GetComponent<Rigidbody>().velocity = activeBullet.transform.forward * bulletSpeed;
        }
		if (Input.GetMouseButtonDown(1)){
			GameObject activeBullet = Instantiate(RailGfx, bulletEmit.position, bulletEmit.rotation);
		}
    }
}
