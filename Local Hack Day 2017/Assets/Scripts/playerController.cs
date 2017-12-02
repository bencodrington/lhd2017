using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {

	private Rigidbody2D rb2d;
	public Animator flash;
	public float playerSpeed;

	public float jumpForce;
	public float fallForce;
	public float defaultGravity;
	public float maxGravity;
	public isHitting weapon;
	private int jumpCap;
	private int numJumps;



	// Use this for initialization
	void Start () {

		jumpCap = 2;
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

		// Trigger flash animation
		flash.SetTrigger("Flash");

		if (weapon.enemies.Length != 0) {
			// Destroy enemies
			for (int i = 0; i < weapon.enemies.Length; i++) {
				weapon.enemies [i].gameObject.GetComponent<enemyController> ().killEnemy();
			}
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

		if (Input.GetKeyDown(KeyCode.RightArrow)) {

			transform.localScale = new Vector3 (-1, 1, 1);
			rb2d.velocity = new Vector2 (playerSpeed, rb2d.velocity.y);

		}

		if (Input.GetKeyDown (KeyCode.LeftArrow)) {

			transform.localScale = new Vector3 (1, 1, 1);
			rb2d.velocity = new Vector2 (-playerSpeed, rb2d.velocity.y);

		}

		/*
		if (Input.GetKey (KeyCode.RightArrow)) {

			rb2d.velocity = new Vector2 (playerSpeed, rb2d.velocity.y);

		}

		if (Input.GetKey (KeyCode.LeftArrow)) {

			rb2d.velocity = new Vector2 (-playerSpeed, rb2d.velocity.y);

		}*/
	}
}
