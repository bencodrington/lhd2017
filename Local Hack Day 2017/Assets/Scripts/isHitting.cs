using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isHitting : MonoBehaviour {

	public Collider2D[] enemies;
	public BoxCollider2D weapon;
	public float weaponOffsetX;
	public float weaponOffsetY;
	public float weaponSize;


	// Use this for initialization
	void Start () {

		enemies = null;
		
	}
	
	// Update is called once per frame
	void Update () {

		checkForCollisions();
		
	}

	void checkForCollisions() {

		// TODO: have a multiplier for which direction the player is facing
		Vector2 point = new Vector2(transform.position.x + weaponOffsetX*transform.localScale.x, transform.position.y + weaponOffsetY);
		int layermask = 1 << LayerMask.NameToLayer("enemy");
		enemies = Physics2D.OverlapCircleAll(point, weaponSize, layermask);
		Debug.DrawLine(transform.position, new Vector3(point.x, point.y));

	}
}
