﻿

//Author:Tilemachos
//this script keeps track of time and what the status of all the Rythm object is
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Timing: MonoBehaviour {

	[Tooltip("Counter of time")]
	public float currentTime = 0.0f;//how much time has passed since last time
	public float sinOfTime;
	[Tooltip("All the rythmic objects need to be here")]
	public Rhythm[] rhythmicObjects;//array of all the objects that follow the beat
	[Tooltip("maximum number of objects, used to reset the turn")]
	public int maxObjects = 4;//maximum number of objects, used to reset the turn
	private int whichSongToPlay = 0;//which song to play indexing
	public float targetTime = 8f;//end of a beat-loop
	private string[] levels = { "State1", "State2", "State3", "State4" };//what the songs are
	[SerializeField]
	private int turn;//whose turn is it
	private bool incremented = true;//bool that describes if I need to change who jumps
	private int oscillationIndex = 0;//who jumps
	public LevelFade transition;
	public string sceneName;

	// Use this for initialization
	void Start () 
	{
		int counter = 0;
		foreach (Rhythm obj in rhythmicObjects) {//for all the rythmic objects
			obj.SetMyTurn(counter);//set their turn, they need to be destroyed in the correct order
			counter++;
		}
		Oscillation osc = rhythmicObjects[oscillationIndex].GetComponentInParent<Oscillation>();
		osc.Activate(); // move
	}
	
	void Update()
	{
		//keep track of time
		currentTime += Time.deltaTime;
		sinOfTime = Mathf.Sin((currentTime) * Mathf.PI);

		//waiting for two secs in order to get into sync
		if(currentTime > 2)
		{
			//change whose turn it is
			if (!incremented && sinOfTime < -0.8)
			{
				Oscillation obj = rhythmicObjects[oscillationIndex].GetComponentInParent<Oscillation>();
				obj.Deactivate();
				if (oscillationIndex < maxObjects - 1) 
				{
					oscillationIndex++;
				}
				else 
				{
					oscillationIndex = 0;
				}
				obj = rhythmicObjects[oscillationIndex].GetComponentInParent<Oscillation>();
				obj.Activate();
				incremented = true;
			}
			else if(incremented && sinOfTime > -0.8) 
			{
				incremented = false;
			}
		}
	}

	//Getter for how much time the loop takes
	public float GetTargetTime()
	{
		return targetTime;
	}
	//Someone has failed. Alert all rythmic objects to reset
	public void SetFail(bool someoneFail){
		
		AkSoundEngine.SetState ("Mechanics_Rhytm", levels [0]);
		whichSongToPlay = 0;
		turn = 0;
		foreach (Rhythm obj in rhythmicObjects) {//for all the rythmic objects
			obj.Reset ();	//reset
		}

	}

//Change the song
	public void ChangeSong()
	{
		
		whichSongToPlay++;//move the index
		if (whichSongToPlay < levels.Length) 
		{
			AkSoundEngine.SetState ("Mechanics_Rhytm", levels [whichSongToPlay]);//which song to play
		}

	}
	//If the right rhytmic object is destroyed this is called
	public void ChangeTurn()
	{
		turn++;
		if(turn == maxObjects){//game has ended, change scene
			transition.FadeIn(sceneName);
		}
	}
	//returns whose turn it is
	public int GetTurn()
	{
		return turn;
	}

}