﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelDifficulty : MonoBehaviour {

	public static int difficulty = 1;
	public static int speed = -1;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (transform.gameObject);

		if (speed > 0 && GameObject.FindGameObjectWithTag("SpeedSlider")) {
			GameObject.FindGameObjectWithTag ("SpeedSlider").GetComponent<Slider> ().value = (float)speed;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public static void StartLevel() {
		speed = (int)GameObject.FindGameObjectWithTag ("SpeedSlider").GetComponent<Slider> ().value;
		SceneManager.LoadScene ("GameScene");
	}
}
