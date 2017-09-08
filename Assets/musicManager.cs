using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		AkSoundEngine.SetState ("Mechanics_Rhytm", "State1"); 
		AkSoundEngine.PostEvent ("Mechanic_rhytmic", gameObject); 
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
