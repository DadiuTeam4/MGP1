﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class mainMusicManager : MonoBehaviour {

	// Use this for initialization

	public string sceneName; 


	void Awake() {
		DontDestroyOnLoad(transform.gameObject);
	}

	void Start () {
		AkSoundEngine.PostEvent ("Main_music", gameObject); 
		AkSoundEngine.SetState ("Scene_change", "OpenScene"); 



			
		
	}
	
	// Update is called once per frame
	void Update () {
		sceneName = SceneManager.GetActiveScene ().name; 


		if (sceneName == "ProtoScene1") 
		{
			AkSoundEngine.SetState ("Scene_change", "ProtoScene1"); 
			//print ("skift"); 
		}

		if (sceneName == "ProtoScene3") 
		{
			AkSoundEngine.SetState ("Scene_change", "ProtoScene3"); 
		}

	




		
		
	}
}