using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {
	public Transform blades;
	public float rotationSpeed;
	void FixedUpdate() 
	{
		Vector3 rotation = new Vector3(blades.eulerAngles.x, blades.eulerAngles.y, blades.eulerAngles.z - rotationSpeed);
		blades.eulerAngles = rotation;
	}
}
