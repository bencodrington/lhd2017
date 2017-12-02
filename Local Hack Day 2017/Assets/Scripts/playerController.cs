﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {

	private Rigidbody2D rb2d;
	public float jumpForce;
	public float fallForce;
	public float defaultGravity;
	public float maxGravity;
	public isHitting weapon;
	private int jumpCap;
	private int numJumps;



	// Use this for initialization
	void Start () {

		jumpCap = 100;
		numJumps = jumpCap;

		rb2d = GetComponent<Rigidbody2D> ();
		
	}

	void gravity() {

		if (rb2d.velocity.y < 0 && rb2d.gravityScale < maxGravity) {

			rb2d.gravityScale += fallForce;
			//Debug.Log ("Less than 0");

		} else {

			rb2d.gravityScale = defaultGravity;

		}
	}
		
	void attack() {

		if (weapon.enemies.Length != 0) {
			// Destroy enemies
			// Reset jump
			numJumps = jumpCap;
		}

	}

	void jump() {

		rb2d.gravityScale = defaultGravity;
		rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
		rb2d.AddForce (transform.up * jumpForce, ForceMode2D.Impulse);
		numJumps -= 1;
	}
	
	// Update is called once per frame
	void Update () {

		handleInput ();

		gravity ();
		
	}

	void handleInput() {
		if (Input.GetKeyDown (KeyCode.Space) && numJumps > 0) {

			jump ();

		}

		if (Input.GetKeyDown (KeyCode.F)) {

			attack ();

		}
	}
}