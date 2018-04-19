using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathMachine1 : MonoBehaviour {
    public GameObject trapProjectileGFX1;       //Get projectile graphic
    public Transform dm1BulletEmitter;
    public float shotRate = 3.0f;
    public float shotDelay = 1.0f;
    public float aimTime = 0.5f;

    private float counter;
    private Vector3 velocity = Vector3.zero;
    private Vector3 aimAt;
    private Vector3 desiredPosition;
    private Vector3 turretHeadPosition;

    AudioSource audioSrc1;

    private void Start()
    {

    }


    void Update () {
        counter += 1 * Time.deltaTime;

        if (counter < shotRate + shotDelay)
        {
            if (GameObject.Find("Player") != null) { desiredPosition = GameObject.Find("Player").transform.position; }
            if (GameObject.Find("Player") == null) { desiredPosition = GameObject.Find("CameraStuff/PlayerView").GetComponent<CursorInteraction>().MouseRayPosition; }
            turretHeadPosition = dm1BulletEmitter.position;
            aimAt = Vector3.SmoothDamp(turretHeadPosition, desiredPosition, ref velocity, aimTime);
            aimAt = new Vector3(aimAt.x, turretHeadPosition.y, aimAt.z);
            dm1BulletEmitter.transform.LookAt(aimAt);
        }
        if (counter >= shotRate + shotDelay){
            FindObjectOfType<Sound>().playSound();
            GameObject activebullet = Instantiate(trapProjectileGFX1, dm1BulletEmitter.transform.position, dm1BulletEmitter.transform.rotation);
            counter = 0;
        }

    }
}
