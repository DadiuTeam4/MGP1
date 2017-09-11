// Author: Itai Yavin
// Contributor:

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpPositionConstructable : MonoBehaviour, Constructable {
	[Tooltip("Step is the amount that the object moves from A to B in the lerp")]
	[Range(0.0f, 1.0f)]
	public float step;

	[Tooltip("The position that the object will have at T = 1")]
	public Transform endPosition;
	[Tooltip("The position that the object will have at T = 0")]
	public Transform startPosition;

	// Variable position within lerp, is always between 0, and 1.
	// 0 = star position
	// 1 = end position
	private float t = 0.0f; 

	void Start(){
		transform.position = Vector3.Lerp(startPosition.position, endPosition.position, t);
	}

	public void Construct(){
		t += step;
		transform.position = Vector3.Lerp(startPosition.position, endPosition.position, t);
	}
}