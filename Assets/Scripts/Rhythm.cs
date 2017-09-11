﻿
//Author: Tilemachos
//Manages the behaviour of all rythm objects
//when you click on something on time it vanishes but it is not destroyed

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rhythm : MonoBehaviour, Touchable {
	public Timing t3; //reference to the timer
	[Tooltip("At which beat in a loop I am activated")]
	public float interval = 2.0f;// Where my beat is
	public bool activate = false;// am I clickable or not
	private MeshRenderer mR; //in order to turn off the mesh
	private Collider collider;//in order to turn off the collider
	private bool destroyed = false; // am I destroyed
	private int myTurn = 0;//is it my turn to be destroyed?

	// Use this for initialization
	void Start () {
		collider = gameObject.GetComponent<Collider>();
		mR = gameObject.GetComponent<MeshRenderer> (); 
		
	}
	
	// Update is called once per frame
	void Update () {

		//if I am on beat
		if (0.0f < (t3.currentTime) - (interval) && (t3.currentTime) - (interval) < 0.3f) {
			interval += t3.GetTargetTime();//move my interval to the next loop 
			activate = true;//Activate me
			gameObject.GetComponent<Renderer>().material.color = Color.green;//make it visible that I am active, turn me green

		} 

		if(t3.currentTime - interval + t3.GetTargetTime() > 0.6f )//if more than 0.3 sec has passed
		{
			if (!destroyed && activate) {//and I am not destroyed but I was active
				t3.SetFail (true);//I failed
			}
		}		
	}

//Manages interaction with the objects 
	public void Interact(RaycastHit hit){
		if(activate && myTurn == t3.GetTurn()){//if I am active and got hit
			//turn everything off and declare that I am now destroyed, also change song and whose turn it is
			mR.enabled = false;
			collider.enabled = false;
			destroyed = true;
			t3.ChangeSong();
			t3.ChangeTurn();
		}
	}

//Resets state 
	public void Reset(){
		//turn everything back to the initial state
		destroyed = false;
		mR.enabled = true;
		collider.enabled = true;
		activate = false;
		gameObject.GetComponent<Renderer>().material.color = Color.white;

	}

	public void SetMyTurn(int whatIsMyTurn){
		myTurn = whatIsMyTurn;
	}


}