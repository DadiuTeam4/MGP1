using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Manages the behaviour of all rythm objects
//when you click on something on time it vanishes but it is not destroyed

public class RhytmScript : MonoBehaviour, Touchable {
	public Timing3 t3; //reference to the timer
	private bool activate = false;// am I clickable or not
	public float interval = 2.0f;// Where my beat is
	private MeshRenderer mR; //in order to turn off the mesh
	private Collider collider;//in order to turn off the collider
	private bool destroyed = false; // am I destroyed
	public int lvl = 0; //need fixing, needs to be on timing3
	private string[] levels = { "State1", "State2", "State3", "State4" };//what the songs are

	// Use this for initialization
	void Start () {
		collider = gameObject.GetComponent<Collider>();
		mR = gameObject.GetComponent<MeshRenderer> (); 
		
	}
	
	// Update is called once per frame
	void Update () {

		//if I am on beat
		if (0.0f < (t3.currentTime) - (interval) && (t3.currentTime) - (interval) < 0.11f) {
			interval += t3.GetTargetTime();//move my interval to the next loop 
			activate = true;//Activate me
			gameObject.GetComponent<Renderer>().material.color = Color.green;//make it visible that I am active, turn me green

		} 

		if(t3.currentTime - interval + t3.GetTargetTime() > 0.3f )//if more than 0.3 sec has passed
		{
			if (!destroyed && activate) {//and I am not destroyed but I was active
				t3.SetFail (true);//I failed
			}
		}		
	}

//Manages interaction with the objects 
	public void Interact(RaycastHit hit){
		if(activate){//if I am active and got hit
			//turn everything off and declare that I am now destroyed, also change song
			mR.enabled = false;
			collider.enabled = false;
			destroyed = true;
			t3.ChangeSong();
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


}
