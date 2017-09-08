using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhytmScript : MonoBehaviour {
	public Timing3 t3; 
	private bool activate = false;
	public float interval = 2.0f;
	private MeshRenderer mR; 
	private bool destroyed = false; 
	public int lvl = 0; 
	public int maxLvl; 
	private string[] levels = { "State1", "State2", "State3", "State4" };

	// Use this for initialization
	void Start () {

		mR = gameObject.GetComponent<MeshRenderer> (); 
		
	}
	
	// Update is called once per frame
	void Update () {


		if (Input.touchCount > 0) {
			if (Input.GetTouch (0).phase == TouchPhase.Began && activate) {
				Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				RaycastHit hit;
				if (Physics.Raycast (ray, out hit, 100f)) {
					Debug.DrawRay (Camera.main.transform.position, hit.point);

					mR.enabled = false;
					destroyed = true;
					lvl++; 

					AkSoundEngine.SetState ("Mechanics_Rhytm", levels [lvl]);

				}
			}
		}

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

	public void Reset(){

		destroyed = false;
		mR.enabled = true;
		activate = false;
		gameObject.GetComponent<Renderer>().material.color = Color.white;
		lvl = 0;
		AkSoundEngine.SetState ("Mechanics_Rhytm", levels [lvl]);
	}


}
