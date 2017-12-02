using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour {

	public GameObject player;
	public float allowance;

	private float newPos;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (player.transform.position.y > transform.position.y + allowance) {
			
			newPos = player.transform.position.y - allowance;
			transform.position = new Vector3 (0, newPos, -10);

		}
		
	}
}
