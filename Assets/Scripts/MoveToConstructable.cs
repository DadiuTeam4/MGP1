using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToConstructable : MonoBehaviour, Constructable {
	public Transform to;
	public float speed;

	private bool startMoving;

	void Update () {
		if(startMoving){
			float step = speed * Time.deltaTime;
			transform.position = Vector3.MoveTowards(transform.position, to.position, step);		
		}
	}

	public void Construct(){
		startMoving = true;
	}
}