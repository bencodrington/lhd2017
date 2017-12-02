using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isHitting : MonoBehaviour {

	private GameObject enemy;
	public bool isOverlap;
	public BoxCollider2D weapon;


	// Use this for initialization
	void Start () {

		enemy = null;
		
	}

	void onCollisionEnter (Collision col) {

		if (col.gameObject.name == "enemy") {

			enemy = col.gameObject;

		}

	}
	
	// Update is called once per frame
	void Update () {

		Debug.Log (LayerMask.NameToLayer ("enemy"));

		if (weapon.IsTouchingLayers (LayerMask.NameToLayer ("enemy"))) {

			isOverlap = true;

		}
		
	}
}
