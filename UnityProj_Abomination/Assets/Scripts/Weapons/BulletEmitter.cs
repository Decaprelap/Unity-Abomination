using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEmitter : MonoBehaviour {
    public Transform bulletEmit;
    public GameObject bulletGfx;
	public GameObject RailGfx;

    public float fireRate;
    private float count;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        count += 1 * Time.deltaTime;
        if (Input.GetMouseButton(0) && !GameObject.Find("Player").GetComponent<Movement>().wishEvade)
        {
            if (count >= fireRate)
            {
                Instantiate(bulletGfx, bulletEmit.position, bulletEmit.rotation);
                count = 0f;
            }

        }
		if (Input.GetMouseButtonDown(1))
        {
			Instantiate(RailGfx, bulletEmit.position, bulletEmit.rotation);
		}
    }
}
