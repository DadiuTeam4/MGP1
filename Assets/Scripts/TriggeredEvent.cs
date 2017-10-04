// Author: Itai Yavin
// Contributor: 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggeredEvent : MonoBehaviour {
	public string triggerTag; // Tag which the code will search for.
	public Animator whaleAnimation;

	// Is called on entering collision with a trigger collider 
	// (a collider can be set as a trigger in the Unity inspector)
	// NOTE: For the purposes of raycasting a Trigger still acts as a collider!
	void OnTriggerEnter(Collider other)
	{
		if(other.transform.tag == triggerTag) {
			gameObject.GetComponent<Constructable>().Construct();
			whaleAnimation.SetTrigger("Trigger");
		}
	}
}
