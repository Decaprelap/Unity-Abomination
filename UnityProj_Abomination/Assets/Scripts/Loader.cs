using System.Collections;
using UnityEngine;

public class Loader : MonoBehaviour {

    public GameObject gameManager;
	// Use this for initialization
	void Awake () {
		if (myGameManager.instance == null) { Instantiate(gameManager); }
	}
}
