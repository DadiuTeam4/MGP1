using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountScript : MonoBehaviour {

	private float timeElapsed = 0.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		timeElapsed += Time.deltaTime;
	}

	bool hitIsSucessful() {
		float nearestInterval = Mathf.Round (timeElapsed);
		float hitOffSet = Mathf.Abs (nearestInterval - timeElapsed);

		float accuracy = 0.2f;
		bool sucess = hitOffSet < accuracy;
		if (sucess) {
			Debug.Log ("Sucess");
		} else {
			Debug.Log ("Fail");
		}

		return sucess;
	}
}
