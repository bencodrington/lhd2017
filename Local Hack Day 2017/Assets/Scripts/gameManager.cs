using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour {

	public static gameManager instance;
	public GameObject gameOverText;
	public bool gameOver = false;

	// Use this for initialization
	void Awake () {

		if (instance == null) {

			instance = this;

		} else if (instance != this) {

			Destroy (gameObject);

		}
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void youDied() {

		gameOverText.SetActive (true);
		gameOver = true;

	}

	public void Reset() {
		gameOver = false;
		gameOverText.SetActive (false);

	}
}
