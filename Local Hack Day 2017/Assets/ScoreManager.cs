using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public Text scoreText;
	public Text highScoreText;

	public Color newHighScoreColor;
	public Color defaultColor;

	public GameObject player;

	private int score;
	private int highScore;

	void Start () {
		score = 0;
		highScore = 0;
	}
	
	int calculateScore() {
		return Mathf.FloorToInt(player.transform.position.y);
	}

	// Update is called once per frame
	void Update () {
		int temp = calculateScore();
		if (temp > score) {
			score = temp;
		}

		if (score >= highScore) {
			highScore = score;
			// Change colour of highScoreText
			highScoreText.color = newHighScoreColor;
		} else {
			// Reset highScoreText colour
			highScoreText.color = defaultColor;
		}

		updateText();
	}

	void updateText() {
		Debug.Log (highScore);
		scoreText.text = score.ToString();
		highScoreText.text = highScore.ToString();
	}

	public void Reset() {
		score = 0;
	}
}
