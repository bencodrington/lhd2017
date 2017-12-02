using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isHitting : MonoBehaviour {

	public Collider2D[] enemies;
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

		Vector2 point = new Vector2(transform.position.x + weaponOffsetX*transform.localScale.x, transform.position.y + weaponOffsetY);
		int layermask = 1 << LayerMask.NameToLayer("enemy");
		enemies = Physics2D.OverlapBoxAll(point, new Vector2(weaponSize, weaponSize), 0f, layermask);

	}
}
