﻿using System.Collections; using System.Collections.Generic; using UnityEngine;  public class StarPool : MonoBehaviour {  	public int starPoolSize = 5; 	public GameObject starPrefab; 	public float starMax; 	public float starMin; 	public float spawnRate = 5f; 	public GameObject camera;   	private GameObject[] stars; 	private float distanceMoved; 	private float spawnYPos; 	private float spawnXPos; 	private int lowestStar = 0; 	private BoxCollider2D currentCol; 	private SpriteRenderer currentSprite;   	public void resetStars() {  		for (int i = 0; i < starPoolSize; i++) {  			stars [i].transform.position = new Vector3 (-10f, i - 8f, -1);  		} 		lowestStar = 0; 	}  	// Use this for initialization 	void Start () {  		stars = new GameObject[starPoolSize];  		for (int i = 0; i < starPoolSize; i++) {  			stars [i] = (GameObject)Instantiate (starPrefab, new Vector3(-10f, i - 8f, -1), Quaternion.identity);  		}  	}  	// Update is called once per frame 	void Update () {  		spawnYPos = camera.transform.position.y + 5f;  		if (stars [lowestStar].transform.position.y < camera.transform.position.y - spawnRate) {  			spawnXPos = Random.Range (starMin, starMax); 			stars[lowestStar].transform.position = new Vector3(spawnXPos, spawnYPos, -0.2f); 			float modifier = Random.Range (0.7f, 1.3f); 			stars [lowestStar].transform.localScale = new Vector3 (stars [lowestStar].transform.localScale.x * modifier, stars [lowestStar].transform.localScale.y * modifier, stars [lowestStar].transform.localScale.z); 			lowestStar++;  			if (lowestStar >= starPoolSize) {  				lowestStar = 0;  			} 		}  	} }  