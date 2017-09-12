using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveMovement : MonoBehaviour {
	public float movementSpeed;
	public float offset;
	public float rangeModifier = 1;
	public bool rotation;
	public float rotationSpeed;
	public float rotationRangeModifier = 1;
	private float sinOfTime;
	private float timer = 0;
	private float originYPos;
	private float originXRot;
	void Start() 
	{
		originYPos = transform.position.y;
		originXRot = transform.eulerAngles.x;
	}
	void FixedUpdate() 
	{
		timer += Time.deltaTime;
		sinOfTime = Mathf.Sin((timer + offset) * movementSpeed);

		float y = originYPos + sinOfTime * rangeModifier;
		transform.position = new Vector3(transform.position.x, y, transform.position.z);
		if (rotation) 
		{
			sinOfTime = Mathf.Sin((timer + offset) * rotationSpeed);
			float xRotation = originXRot + sinOfTime * rotationRangeModifier;
			transform.eulerAngles = new Vector3(xRotation, transform.eulerAngles.y, transform.eulerAngles.z);
		}
	}
}
