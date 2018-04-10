using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    // Movement and jump speeds
    public float maxMoveSpeed = 10.0f;
    private float currentMoveSpeed;

    // Get Camera and Player Object
    public Transform Player;

    // EVADE SYSTEM \\
    public bool wishEvade = false;
    private Vector3 moveDir;

    public float evadeDuration = 2.0f;      // Full duration of evade maneuver
    public float evadeAccelTime = 0.5f;     // % of evade duration spent accelerating
    public float evadeMaxSpeed = 1.0f;      // Max speed to accelerate towards
    public float evadeCooldown = 3.0f;      // Cooldown of evade Maneuver
    private float evadeReady;               // Cooldown counter
    private float evadeSpeed;               // Current speed of evade maneuver
    private float evadeCounter = 0.0f;      // Time elapsed during evade maneuver

    private bool wishEvade_W = false;
    private bool wishEvade_S = false;
    private bool wishEvade_D = false;
    private bool wishEvade_A = false;

    // MISC VARIABLES \\
    private float t = 0.0f;


    void Start()
    {
        // Hides cursor
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;

        // Uses input acceleration time as % of full evade duration
        evadeAccelTime = evadeDuration * evadeAccelTime;
        evadeReady = evadeCooldown;
    }

    void Update()
    {
        // Get players position
        Vector3 playerposition = Player.transform.position;

        // Makes cursor lock to window when clicking the play window
        if (Cursor.lockState != CursorLockMode.Confined)
        {
            if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
                Cursor.lockState = CursorLockMode.Confined;
        }


        // PLAYER MOVEMENT \\
        // Diagonal moves faster so hit up stack overflow
        var z = Input.GetAxis("Vertical") * maxMoveSpeed * Time.deltaTime;
        var x = Input.GetAxis("Horizontal") * maxMoveSpeed * Time.deltaTime;
        currentMoveSpeed = Mathf.Pow(Mathf.Pow(x/Time.deltaTime,2) + Mathf.Pow(z / Time.deltaTime, 2),0.5f);
        //Debug.Log("Speed: " + currentMoveSpeed);
        if (!wishEvade) {
            transform.Translate(x, 0, z, Space.World);
        }
        Evade();



    }

	private void OnTriggerEnter(Collider other) {
        Debug.Log("Colliding With" + other);
		if (other.gameObject.tag == "Hitbox" && !wishEvade || other.gameObject.tag == "Hazard" && !wishEvade) {
			Debug.Log("A " + other + " killed you");
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
	}


    void Evade() {
        if (!wishEvade) {
            wishEvade_W = false;
            wishEvade_S = false;
            wishEvade_D = false;
            wishEvade_A = false;

            if (Input.GetKey("w")) {
                wishEvade_W = true;
            }
            if (Input.GetKey("s")) {
                wishEvade_S = true;
            }
            if (Input.GetKey("d")) {
                wishEvade_D = true;
            }
            if (Input.GetKey("a")) {
                wishEvade_A = true;
            }

            /* Debug.Log("W " + wishEvade_W);
               Debug.Log("S " + wishEvade_S);
               Debug.Log("D " + wishEvade_D);
               Debug.Log("A " + wishEvade_A); */

            if (evadeReady < evadeCooldown) { 
                evadeReady += 1.0f * Time.deltaTime;
            } else {
                Debug.Log("Evade Ready");
            }

            t = 0;
            evadeCounter = 0.0f;
        }

        if (Input.GetButtonDown("Evade") && evadeReady >= evadeCooldown) {
            wishEvade = true;
        }
        if (wishEvade && evadeReady >= evadeCooldown) {
            evadeCounter += 1 * Time.deltaTime;


            // Acceleration and decceleration function
            if (evadeCounter < evadeDuration) {
                evadeSpeed = Mathf.Lerp(currentMoveSpeed, evadeMaxSpeed, t);
                t += 1/evadeAccelTime * Time.deltaTime;
                if (evadeCounter >= evadeDuration - evadeAccelTime) {
                    evadeSpeed = Mathf.Lerp(evadeMaxSpeed, currentMoveSpeed, t);
                    t += 1 / evadeAccelTime * Time.deltaTime;
                }

               // Debug.Log(evadeSpeed);
                if (wishEvade_W) {
                    transform.Translate(0, 0, evadeSpeed * Time.deltaTime, Space.World);
                }
                if (wishEvade_S) {
                    transform.Translate(0, 0, -evadeSpeed * Time.deltaTime, Space.World);
                }
                if (wishEvade_D) {
                    transform.Translate(evadeSpeed * Time.deltaTime, 0, 0, Space.World);
                }
                if (wishEvade_A) {
                    transform.Translate(-evadeSpeed * Time.deltaTime, 0, 0, Space.World);
                }
            }
            // After evade maneuver
            if (evadeCounter >= evadeDuration) {
                evadeReady = 0;
                wishEvade = false;
            }
        }
    }
}