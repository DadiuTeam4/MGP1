

//Author:Tilemachos
//this script keeps track of time and what the status of all the Rythm object is
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Timing: MonoBehaviour {

	[Tooltip("Counter of time")]
	public float currentTime = 0.0f;//how much time has passed since last time
	[Tooltip("All the rythmic objects need to be here")]
	public Rhythm[] rhythmicObjects;//array of all the objects that follow the beat
	[Tooltip("maximum number of objects, used to reset the turn")]
	public int maxObjects = 4;//maximum number of objects, used to reset the turn
	private int whichSongToPlay = 0;//which song to play indexing
	private float targetTime = 8f;//end of a beat-loop
	private string[] levels = { "State1", "State2", "State3", "State4" };//what the songs are
	[SerializeField]
	private int turn;

	// Use this for initialization
	void Start () {
		int counter = 0;
		foreach (Rhythm obj in rhythmicObjects) {//for all the rythmic objects
			obj.SetMyTurn(counter);//set their turn, they need to be destroyed in the correct order
			counter++;
		}
		
	}
	
	void Update(){
		//keep track of time
		currentTime += Time.deltaTime;
	}

	//Getter for how much time the loop takes
	public float GetTargetTime(){
		return targetTime;
	}
	//Someone has failed. Alert all rythmic objects to reset
	public void SetFail(bool someoneFail){
		
		AkSoundEngine.SetState ("Mechanics_Rhytm", levels [0]);
		whichSongToPlay = 0;
		foreach (Rhythm obj in rhythmicObjects) {//for all the rythmic objects
			obj.Reset ();	//reset
		}

	}

//Change the song
	public void ChangeSong(){
		
		whichSongToPlay++;//move the index
	
		AkSoundEngine.SetState ("Mechanics_Rhytm", levels [whichSongToPlay]);//which song to play

	}
	//If the right rhytmic object is destroyed this is called
	public void ChangeTurn(){
		turn++;
		if(turn == maxObjects){//for four objects, reset
			turn = 0;
		}
	}
	//returns whose turn it is
	public int GetTurn(){
		return turn;
	}

}