﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatcherPanelManager : MonoBehaviour {

	private Transform[] matcherNumbers;
	private GameObject numberPanelManager;
	private int difficulty;

	public AudioSource solvedSound;

	void Awake()
	{
		// get all numbers on the panel
		matcherNumbers = new Transform[transform.childCount];

		for (int i = 0; i < transform.childCount; i++) {
			matcherNumbers[i] = transform.GetChild (i);
		}

		solvedSound.volume = Soundtrack.volume;
		numberPanelManager = GameObject.FindGameObjectWithTag ("NumberPanel");
	}

	public void SetDifficulty(int diff) {
		difficulty = diff;

		if (difficulty == 1) {
			matcherNumbers [0].gameObject.SetActive (false);
			matcherNumbers [1].gameObject.SetActive (false);
			matcherNumbers [2].gameObject.SetActive (false);
			matcherNumbers [3].gameObject.SetActive (true);
			matcherNumbers [4].gameObject.SetActive (true);
			matcherNumbers [5].gameObject.SetActive (false);
			matcherNumbers [6].gameObject.SetActive (false);
			matcherNumbers [7].gameObject.SetActive (false);
		} else if (difficulty == 2) {
			matcherNumbers [0].gameObject.SetActive (false);
			matcherNumbers [1].gameObject.SetActive (false);
			matcherNumbers [2].gameObject.SetActive (true);
			matcherNumbers [3].gameObject.SetActive (true);
			matcherNumbers [4].gameObject.SetActive (true);
			matcherNumbers [5].gameObject.SetActive (true);
			matcherNumbers [6].gameObject.SetActive (false);
			matcherNumbers [7].gameObject.SetActive (false);
		} else if (difficulty == 3) {
			matcherNumbers [0].gameObject.SetActive (false);
			matcherNumbers [1].gameObject.SetActive (true);
			matcherNumbers [2].gameObject.SetActive (true);
			matcherNumbers [3].gameObject.SetActive (true);
			matcherNumbers [4].gameObject.SetActive (true);
			matcherNumbers [5].gameObject.SetActive (true);
			matcherNumbers [6].gameObject.SetActive (true);
			matcherNumbers [7].gameObject.SetActive (false);
		} else if (difficulty == 4) {
			matcherNumbers [0].gameObject.SetActive (true);
			matcherNumbers [1].gameObject.SetActive (true);
			matcherNumbers [2].gameObject.SetActive (true);
			matcherNumbers [3].gameObject.SetActive (true);
			matcherNumbers [4].gameObject.SetActive (true);
			matcherNumbers [5].gameObject.SetActive (true);
			matcherNumbers [6].gameObject.SetActive (true);
			matcherNumbers [7].gameObject.SetActive (true);
		}
	}

	public int GetDifficulty() {
		return difficulty;
	}

	// Use this for initialization
	void Start () {
		SetDifficulty (LevelDifficulty.difficulty);
	}
	
	// Update is called once per frame
	void Update () {
		if (difficulty == 4) {
			if (IsMatching(0,10) && IsMatching(1,11) && IsMatching(2,12) && IsMatching(3,13)&& 
				IsMatching(4,14) && IsMatching(5,15) && IsMatching(6,16) && IsMatching(7,17)) {
				GameObject.Find("SoundTrack").GetComponent<Soundtrack>().StopMusic ();
				solvedSound.Play ();
				GameObject.FindGameObjectWithTag ("CompleteLevel").GetComponent<CompleteLevel> ().EndLevel ();
			}
		}
		else if (difficulty == 3) {
			if (IsMatching(1,11) && IsMatching(2,12) && IsMatching(3,13)&& 
				IsMatching(4,14) && IsMatching(5,15) && IsMatching(6,16)) {
				GameObject.Find("SoundTrack").GetComponent<Soundtrack>().StopMusic ();
				solvedSound.Play ();
				GameObject.FindGameObjectWithTag ("CompleteLevel").GetComponent<CompleteLevel> ().EndLevel ();
			}
		}
		else if (difficulty == 2) {
			if (IsMatching(2,12) && IsMatching(3,13)&& 
				IsMatching(4,14) && IsMatching(5,15)) {
				GameObject.Find("SoundTrack").GetComponent<Soundtrack>().StopMusic ();
				solvedSound.Play ();
				GameObject.FindGameObjectWithTag ("CompleteLevel").GetComponent<CompleteLevel> ().EndLevel ();
			}
		}
		else if (difficulty == 1) {
			if (IsMatching(3,13)&& 
				IsMatching(4,14)) {
				GameObject.Find("SoundTrack").GetComponent<Soundtrack>().StopMusic ();
				solvedSound.Play ();
				GameObject.FindGameObjectWithTag ("CompleteLevel").GetComponent<CompleteLevel> ().EndLevel ();
			}
		}
	}

	bool IsMatching(int matcherNumber, int panelNumber) {
		return matcherNumbers [matcherNumber].GetComponent<PanelNumber> ().assignedNumber ==
		numberPanelManager.GetComponent<NumberPanelManager> ().getPanelNumbers () [panelNumber].GetComponent<PanelNumber> ().assignedNumber;
	}
}
