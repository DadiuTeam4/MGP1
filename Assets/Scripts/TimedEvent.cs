using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedEvent : MonoBehaviour {
	public float timeMinutes;
	public float timeSeconds;


	public Constructable test;
	private float timeTillEvent;
	private float timeStamp;


	// Use this for initialization
	void Start () {
		timeTillEvent = timeSeconds + (timeMinutes * 60);
		timeStamp = Time.time + timeTillEvent;
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time > timeStamp){
			gameObject.GetComponent<Constructable>().Construct();
		}
	}
}
