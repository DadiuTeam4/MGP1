using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggeredEvent : MonoBehaviour {

	public string triggerTag;

	void OnTriggerEnter(Collider other)
	{
		if(other.transform.tag == triggerTag) {
			gameObject.GetComponent<Constructable>().Construct();
		}
	}
}
