using UnityEngine;

public class Movement : MonoBehaviour
{
    // Movement and jump speeds
    public float MoveSpeed = 10.0f;

    // Get Camera and Player Object
    public Transform PlayerView;
    public Transform Player;
    private CharacterController Controller;


    void Start()
    {
        // Hides cursor
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        // Finds the CharacterController component in object with this script
		Controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Get players position
        Vector3 playerposition = Player.transform.position;

        // Makes cursor lock when clicking the play window
        if (Cursor.lockState != CursorLockMode.Locked)
        {
            if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
                Cursor.lockState = CursorLockMode.Locked;
        }

        // PLAYER MOVEMENT \\
        var z = Input.GetAxis("Vertical") * Time.deltaTime * MoveSpeed;
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * MoveSpeed;
		transform.Translate(x-z, 0, z+x);

		if (Input.GetButtonDown ("Evade"))
			transform.Translate(5,0,0);
    }
}
