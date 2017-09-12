using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveMovement : MonoBehaviour {
	private float sinOfTime;
	private float timer = 0;
	public float offset;
	void FixedUpdate() 
	{
		timer += Time.deltaTime;
		sinOfTime = Mathf.Sin(timer + offset);

		float y = transform.position.y + sinOfTime * 0.1f;
		transform.position = new Vector3(transform.position.x, y, transform.position.z);
	}
}
