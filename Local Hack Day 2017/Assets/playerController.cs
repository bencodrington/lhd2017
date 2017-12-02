using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {

	private Rigidbody2D rb2d;
	public float jumpForce;
	public float fallForce;
	public float defaultGravity;
	public float maxGravity;
	public BoxCollider2D weapon;



	// Use this for initialization
	void Start () {

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



	}

	void jump() {

		rb2d.AddForce (transform.up * jumpForce, ForceMode2D.Impulse);

	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.Space)) {

			jump ();

		}

		gravity ();
		
	}
}
