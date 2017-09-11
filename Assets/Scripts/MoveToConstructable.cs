// Author: Itai Yavin
// Contributor:

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToConstructable : MonoBehaviour, Constructable {
	[Tooltip("End position")]
	public Transform to;
	public float speed;

	[Tooltip("If false = Moves this object. If true = moves targeted object instead")]
	public bool moveTarget;
	[Tooltip("Object which will be moved if moveTarget bool is true")]
	public Transform target;

	private bool startMoving;

	void Update () {
		if(startMoving)
		{
			float step = speed * Time.deltaTime;
			if(!moveTarget)
			{
				transform.position = Vector3.MoveTowards(transform.position, to.position, step);		
			} 
			else 
			{
				target.transform.position = Vector3.MoveTowards(target.transform.position, to.position, step);
			}
		}
	}

	public void Construct()
	{
		startMoving = true;
	}
}