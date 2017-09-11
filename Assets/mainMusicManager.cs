using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainMusicManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		AkSoundEngine.PostEvent ("Main_music", gameObject); 
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
