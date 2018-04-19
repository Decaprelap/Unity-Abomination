using UnityEngine;
using UnityEngine.SceneManagement;

public class CursorInteraction : MonoBehaviour {

	public Camera cam;
	public Vector3 MouseRayPosition;
    public Grid grid;
    public GameObject player;
    public GameObject playerSpawn;
    public GameObject[] rooms;

    private Vector3 emitterHeight;                              // Player BulletEmitter Height
    private Vector3 floorOffset = Vector3.zero;                 // Ground plane Offset
    private float distance;
    private int selectedRoom;
    private Ray ray;

    private bool building = false;

    void Start ()
    {
        if (GameObject.Find("Player") != null)
        {
            emitterHeight = new Vector3(0, GameObject.Find("Player/BulletEmitter").transform.position.y, 0);
        }
        if (GameObject.Find("Player") == null)
        {
            Debug.Log("No player in scene");
            return;
        }
    }

    void Update () {
		// Shoot a ray from mouse position
		ray = cam.ScreenPointToRay(Input.mousePosition);

		// Create a plane across Y = 0 to collide with
		Plane hPlane = new Plane(Vector3.up, Vector3.zero + floorOffset);

		// Get point at Y = 0 where ray collides
		if (hPlane.Raycast(ray, out distance))
			MouseRayPosition = ray.GetPoint(distance);      // Mouse ray intersecting Y = 0 (+ floorOffset) position

        // Perform this code if there is no active character eg.Level Editor
        if (GameObject.Find("Player") == null) {
            PlayEdit();
            return;
		}

		// Perform this code if there is an active character eg.Raiding
		if (GameObject.Find("Player") != null) {
            PlayRaid();
		}
	}

    void PlaceRoom(Vector3 nearPoint)
    {
        float size = GameObject.Find("Grid").GetComponent<EditorGrid>().size;
        var finalPosition = GameObject.Find("Grid").GetComponent<EditorGrid>().GetNearestPointOnGrid(nearPoint,true);
        // var finalScale = GameObject.Find("Grid").GetComponent<EditorGrid>().scaleVec3;
        // finalPosition = new Vector3(finalPosition.x / finalScale.x, finalPosition.y / finalScale.y, finalPosition.z / finalScale.z);
        Debug.Log("position = " + finalPosition);
        Debug.Log(("Position.x % (size*2) = ") + (finalPosition.x % (size * 2)));
        Debug.Log(("Position.y % (size*2) = ") + (finalPosition.y % (size * 2)));
        if (finalPosition.x % (size * 10) == 0 && finalPosition.z % (size * 5f) == 0)
        {
            GameObject roomInst = Instantiate(rooms[selectedRoom], finalPosition, Quaternion.Euler(0, 45, 0));
            roomInst.transform.position = finalPosition;
           // roomInst.transform.localScale = new Vector3(1,1,1);
        }
    }

    void PlayEdit()
    {
        floorOffset = Vector3.zero;                         // Makes cursor click intersect with y=0;
        Debug.Log("Editor");                                // Ensures FaceMouse is on the right scene

        if (Input.GetKeyDown("1"))
        {
            building = true;
            selectedRoom = 0;
        }
        if (Input.GetKeyDown("2"))
        {

            building = true;
            selectedRoom = 1;
        }
        if (Input.GetKeyDown("3"))
        {
            building = true;
            selectedRoom = 2;
        }
        if (Input.GetMouseButtonDown(1))
        {
            Destroy(GameObject.Find("PlayerSpawn(clone)")); 
            Instantiate(playerSpawn, new Vector3(MouseRayPosition.x, 0.5f, MouseRayPosition.z), Quaternion.Euler(0,45,0));
        }
        if (Input.GetMouseButtonDown(0) && !building)
        {
            GameObject.Find("CameraStuff/CameraFollow").transform.position = MouseRayPosition;
            Debug.Log("Pan to mouse");
        }
        if (building)
        {
            RaycastHit hitinfo;
            Debug.Log("cursor snap to :");
            if (Input.GetMouseButtonDown(0))
            {
                if (Physics.Raycast(ray, out hitinfo)) { PlaceRoom(hitinfo.point); }
            }
        }
    }
    void PlayRaid()
    {

        floorOffset = emitterHeight;                            // Character aims from eyeHeight
        MouseRayPosition.y = player.transform.position.y;   // Make sure the player looks parallel to ground only
        Debug.Log("Combat");                               // Ensures FaceMouse is on the right scene

        // Look at Y intersect
        player.transform.LookAt(MouseRayPosition);
    }
}
