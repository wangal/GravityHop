﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelClear : MonoBehaviour {
    //central state machine
    public CentralStateScript stateMachine;
    Animator anim;
    bool displayScore;
    // Use this for initialization
    void Start () {
        if (stateMachine == null)
            stateMachine = GameObject.FindGameObjectWithTag("SM").GetComponent<CentralStateScript>();
        anim = GetComponent<Animator>();
        displayScore = false;

    }

    // Update is called once per frame
    void Update () {
		if (Input.GetKey ("w")) {
			stateMachine.Victory ();
		}
        if (displayScore == false && stateMachine.getGameState() == CentralStateScript.GameState.Victory)
        {
            LevelCleared();
            displayScore = true;
        }
	}

    void LevelCleared()
    {
		anim.SetTrigger("LevelCleared");
		int level = SceneManager.GetActiveScene().buildIndex;
		int stars = 0;
		//A different scoring requirement for each level
		switch (level) {
		case 1: 
			if (stateMachine.getScore () >= 1000) {
				stars = 1;
			}
			if (stateMachine.getScore () >= 2000) {
				stars = 2;
			}
			if (stateMachine.getScore () >= 2500) {
				stars = 3;
			}
			break;
		case 2: 
			if (stateMachine.getScore () >= 1000) {
				stars = 1;
			}
			if (stateMachine.getScore () >= 2000) {
				stars = 2;
			}
			if (stateMachine.getScore () >= 2500) {
				stars = 3;
			}
			break;
		case 3: 
			if (stateMachine.getScore () >= 1000) {
				stars = 1;
			}
			if (stateMachine.getScore () >= 2000) {
				stars = 2;
			}
			if (stateMachine.getScore () >= 2500) {
				stars = 3;
			}
			break;
		case 4: 
			if (stateMachine.getScore () >= 1000) {
				stars = 1;
			}
			if (stateMachine.getScore () >= 2000) {
				stars = 2;
			}
			if (stateMachine.getScore () >= 2500) {
				stars = 3;
			}
			break;
		default:
			stars = 0;
			break;
		}
		if (PlayerPrefs.GetInt ("Level" + level.ToString ()) < stars) {
			PlayerPrefs.SetInt ("Level" + (level).ToString (), stars);
		}
    }

    public void NextLevel()
    {

		SceneManager.LoadScene(SceneManager.GetActiveScene ().buildIndex + 1);
    }

	public void StartMenu()
	{
		SceneManager.LoadScene(0);
	}
}
