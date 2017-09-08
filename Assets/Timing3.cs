using UnityEngine;
using System.Collections;
using System.Collections.Generic;


//this script keeps track of time and what the status of all the Rythm object is
public class Timing3: MonoBehaviour {

	private int whichSongToPlay = 0;//which song to play indexing
	private float targetTime = 8f;//end of a beat-loop
	private string[] levels = { "State1", "State2", "State3", "State4" };//what the songs are
	public float currentTime = 0.0f;//how much time has passed since last time
	public RhytmScript[] rhythmicObjects;//array of all the objects that follow the beat

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
		foreach (RhytmScript obj in rhythmicObjects) {//for all the rythmic objects
			obj.Reset ();	//reset
		}

	}

//Change the song
	public void ChangeSong(){
		
		whichSongToPlay++;//move the index
	
		AkSoundEngine.SetState ("Mechanics_Rhytm", levels [whichSongToPlay]);//which song to play

	}

}