using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {

	private Rigidbody2D rb2d;
	public Animator flash;
	public float launch;
	public float playerSpeed;
	public GameObject camera;
	public gameManager gameManager;
	public ScoreManager scoreManager;
	public enemyPool enemies;
	public StarPool stars;

	public AudioSource attackSound;
	public AudioSource jumpSound;

	public float jumpForce;
	public float fallForce;
	public float defaultGravity;
	public float maxGravity;
	public isHitting weapon;

	public Vector3 startPos;
	private Quaternion startRot = Quaternion.identity;
	private int jumpCap;
	private int numJumps;



	// Use this for initialization
	void Start () {

		jumpCap = 2;
		numJumps = jumpCap;

		rb2d = GetComponent<Rigidbody2D> ();
		rb2d.AddForce (transform.up * launch, ForceMode2D.Impulse);
		
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

		// Play attack sound
		attackSound.Play();

	}

	void jump() {

		rb2d.gravityScale = defaultGravity;
		rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
		rb2d.AddForce (transform.up * jumpForce, ForceMode2D.Impulse);
		numJumps -= 1;

		// Play jump sound
		jumpSound.Play();
	}
	
	// Update is called once per frame
	void Update () {

		handleInput ();

		gravity ();

		if (transform.position.y < camera.transform.position.y - 8) {

			gameManager.youDied ();

		}
		
	}

	void handleInput() {

		if (gameManager.gameOver) {
			if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.F)) {
				gameManager.Reset();
				scoreManager.Reset();
				stars.resetStars();
				enemies.resetEnemies();
				camera.transform.position = new Vector3 (0, 0, -10);
				Reset();
			}
			return;
		}


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
	}

	void Reset() {
		// Reset Position and Rotation
		transform.position = startPos;
		transform.rotation = startRot;
		transform.localScale = new Vector3(1, 1, 1);
		numJumps = jumpCap;
		rb2d.velocity = new Vector2(0, 0);
		rb2d.AddForce (transform.up * launch, ForceMode2D.Impulse);

	}
}
