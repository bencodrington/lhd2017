﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyPool : MonoBehaviour {

	public int enemyPoolSize = 5;
	public GameObject enemyPrefab;
	public float enemyMaxX;
	public float enemyMinX;
	public float spawnRate = 5f;
	public GameObject camera;


	private GameObject[] enemies;
	private float distanceMoved;
	private float spawnYPos;
	private float spawnXPos;
	private int lowestEnemy = 0;

	// Use this for initialization
	void Start () {

		enemies = new GameObject[enemyPoolSize];

		for (int i = 0; i < enemyPoolSize; i++) {

			enemies [i] = (GameObject)Instantiate (enemyPrefab, new Vector2(-10f, i*4f), Quaternion.identity);

		}
		
	}
	
	// Update is called once per frame
	void Update () {

		spawnYPos = camera.transform.position.y + 5f;

		if (enemies [lowestEnemy].transform.position.y < camera.transform.position.y - spawnRate) {

			spawnXPos = Random.Range (enemyMinX, enemyMaxX);
			enemies[lowestEnemy].transform.position = new Vector2(spawnXPos, spawnYPos);
			lowestEnemy++;

			if (lowestEnemy >= enemyPoolSize) {

				lowestEnemy = 0;

			}
		}
		
	}
}