using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhytmScript : MonoBehaviour, Touchable {
	public Timing3 t3; 
	private bool activate = false;
	public float interval = 2.0f;
	private MeshRenderer mR; 
	private Collider collider;
	private bool destroyed = false; 
	public int lvl = 0; 
	public int maxLvl; 
	private string[] levels = { "State1", "State2", "State3", "State4" };

	// Use this for initialization
	void Start () {
		collider = gameObject.GetComponent<Collider>();
		mR = gameObject.GetComponent<MeshRenderer> (); 
		
	}
	
	// Update is called once per frame
	void Update () {
<<<<<<< HEAD

=======
>>>>>>> TouchHandling
		if (0.0f < (t3.currentTime) - (interval) && (t3.currentTime) - (interval) < 0.11f) {
			interval += t3.GetTargetTime();
			activate = true;
			gameObject.GetComponent<Renderer>().material.color = Color.green;

		} 

		if(t3.currentTime - interval + t3.GetTargetTime() > 0.3f )
		{
			if (!destroyed && activate) {
				t3.SetFail (true);

			}

		}
			
	}

	public void Interact(RaycastHit hit){
		if(activate){
			mR.enabled = false;
			collider.enabled = false;
			destroyed = true;
			lvl++; 

			AkSoundEngine.SetState ("Mechanics_Rhytm", levels [lvl]);
		}
	}

	public void Reset(){

		destroyed = false;
		mR.enabled = true;
		collider.enabled = true;
		activate = false;
		gameObject.GetComponent<Renderer>().material.color = Color.white;
		lvl = 0;
		AkSoundEngine.SetState ("Mechanics_Rhytm", levels [lvl]);
	}


}
