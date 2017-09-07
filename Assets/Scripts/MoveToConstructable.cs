using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToConstructable : MonoBehaviour {
	public Transform to;
	public float speed;

	void Update () {
        float step = speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards(transform.position, to.position, step);		
	}
}