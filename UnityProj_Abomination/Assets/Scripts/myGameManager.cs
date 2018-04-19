using UnityEngine.SceneManagement;
using UnityEngine;

public class myGameManager : MonoBehaviour {

    public static myGameManager instance = null;
    public GameObject map;

	// Use this for initialization
	void Awake ()
    {
		if (instance == null) { instance = this; }
        else if (instance != this) { Destroy(gameObject); }

        DontDestroyOnLoad(gameObject);
        InitGame();
	}
	
    void InitGame()
    {
       SceneManager.LoadScene("Main");
    }
	// Update is called once per frame
	void Update () 
	{
		
		// Press R to restart
		if (Input.GetKeyDown(KeyCode.R)) SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        if (Input.GetKeyDown(KeyCode.N)) SceneManager.LoadScene("Raid");
        if (Input.GetKeyDown(KeyCode.M)) SceneManager.LoadScene("BaseEditor");
        if (Input.GetKeyDown(KeyCode.B)) SceneManager.LoadScene("Main");
    }
}
