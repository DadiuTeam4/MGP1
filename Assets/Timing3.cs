using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Timing3: MonoBehaviour {

	private float targetTime = 8f;
	public float currentTime = 0.0f;
	private bool fail = false;
	public RhytmScript[] rhythmicObjects;

	void Awake(){

	}


	void Update(){

		currentTime += Time.deltaTime;

		if (currentTime >= 8f)
		{
		//	timerEnded();
		}
		//Debug.Log (currentTime); 

	}

	public float GetTargetTime(){
		return targetTime;
	}
	public void SetFail(bool someoneFail){
		fail = someoneFail;
		foreach (RhytmScript obj in rhythmicObjects) {
			obj.Reset ();
		
		}

	}
	public bool GetFail()
	{
		return fail;
	}

	void timerEnded()
	{
		//do your stuff here.
		print ("8 secs have passed"); 
		//currentTime = 0.0f;
	}


}