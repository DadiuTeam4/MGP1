using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rhythmic : MonoBehaviour 
{
	public int interval;
	public int delay;
	private int currentBeat;
	void Start() 
	{
		currentBeat = 0;
	}
	public void IncrementCurrentBeat() 
	{
		// Increments the beat for this object
		currentBeat++;
		print(currentBeat);
		if (currentBeat >= 0 && currentBeat % interval == 0) 
		{
			Interact();
		}
	}

	// Abstract function to override
	protected virtual void Interact() {}
}
