// Author: Itai Yavin
// Contributor:

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedEvent : MonoBehaviour {
	[Tooltip("Time in minutes untill event trigger. Is translated to seconds")]
	public float timeMinutes;
	[Tooltip("Time in seconds untill event trigger.")]
	public float timeSeconds;

	private float timeStamp; 	// Contains the calculated time when event trigger.
	private float timeTillEvent;// The translated and added mintes and seconds till event trigger.

	// Use this for initialization
	void Start () 
	{
		timeTillEvent = timeSeconds + (timeMinutes * 60);
		timeStamp = Time.time + timeTillEvent;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Time.time > timeStamp)
		{
			gameObject.GetComponent<Constructable>().Construct();
		}
	}
}
