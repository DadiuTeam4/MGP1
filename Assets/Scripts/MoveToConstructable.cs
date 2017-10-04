// Author: Itai Yavin
// Contributor:

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveToConstructable : MonoBehaviour, Constructable {
	[Tooltip("End position")]
	public Transform to;
	public float speed;

	[Tooltip("If false = Moves this object. If true = moves targeted object instead")]
	public bool moveTarget;
	[Tooltip("Object which will be moved if moveTarget bool is true")]
	public Transform target;
	private Transform targetStart;


	[Tooltip("Hugo will more to this destination when the camera movement starts")]
	public Transform hugoMovementDestination;

	[Tooltip("Should only be true if you want Hugo to move as well!")]
	public bool moveHugo = false;

	private NavMeshAgent hugoAI;

	private bool startMoving;

	void Start()
	{
		hugoAI = GameObject.FindGameObjectWithTag("Player").GetComponent<NavMeshAgent>();
		targetStart = target.transform;
	}

	void Update () {
		if(startMoving)
		{

			if(moveHugo)
			{
				hugoAI.SetDestination(hugoMovementDestination.position);
				moveHugo = false;
			}

			float step = speed * Time.deltaTime;
			if(!moveTarget)
			{
				transform.position = Vector3.MoveTowards(transform.position, to.position, step);		
			} 
			else 
			{
				target.transform.position = Vector3.MoveTowards(target.transform.position, to.position, step);
				target.rotation = Quaternion.Lerp(targetStart.rotation, to.rotation, step);
			}
		}
	}

	public void Construct()
	{
		startMoving = true;
	}
}