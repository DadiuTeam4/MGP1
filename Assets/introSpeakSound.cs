using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class introSpeakSound : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void IntroSpeakSound()
	{
		AkSoundEngine.PostEvent ("Speak_intro", gameObject); 
	}

}
