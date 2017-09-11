using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Makes the object oscillate between two points
public class Oscillation : MonoBehaviour 
{
	public Timing timing;
	public Transform upperBound;
	public Transform lowerBound;
	private bool active = false;
	private Rhythm rhythmObject;

	void Start() 
	{
		rhythmObject = GetComponentInChildren<Rhythm>();
	}


	void FixedUpdate() 
	{
		if (active) 
		{
			float f = timing.sinOfTime;
			Vector3 position = Vector3.Lerp(lowerBound.position, upperBound.position, (f + 1) / 2);
			rhythmObject.gameObject.transform.position = position;
		}
		else 
		{
			rhythmObject.gameObject.transform.position = lowerBound.position;
		}
	}

	public void Activate() 
	{
		active = true;
	}

	public void Deactivate() 
	{
		active = false;
	}
}
