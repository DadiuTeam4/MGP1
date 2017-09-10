// Author: Itai Yavin
// Contributor:

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class Number : MonoBehaviour, Touchable
{
	[Tooltip("The value which determines what list of constructable objects are called")]
	public int value;
	[Tooltip("If the player is further away than this, he will move to the number first")]
	public float WalkToDistance = 1.0f;

	private Rigidbody rig; 								// The objects own rigidbody
	private Vector3 burstDirection; 					// The direction which the object will move upon burst - See function Burst()
	private float burstSpeed; 							// The speed which the object will move upon burst - See function Burst()
	private ConstructionHandler constructionHandler;
	private PlayerAI hugo;

	void Start() 
	{
		rig = gameObject.GetComponent<Rigidbody>();
		hugo = FindObjectOfType<PlayerAI>();	
	}

	// Will push the object in a single burst of force.
	public void Burst()
	{
		rig.AddForce(burstDirection * burstSpeed);
	}

	// Interact function from Touchable Interface
	// Will set the destination for the playerAI so that the player will move to destination.
	// When clicking/touching a number the player will move to it
	public void Interact(RaycastHit hit) 
	{
		if (Vector3.Distance(hugo.transform.position, transform.transform.position) > WalkToDistance)
		{
			hugo.playerAI.SetDestination(hit.point);
		}
	}

	// Ontrigger enter the number is picked up and the numbers value is given to the constructionHandler.
	// The object is disabled thereafter.
	void OnTriggerEnter(Collider other)
	{
		if(other.transform.tag == "Player")
		{
			constructionHandler.SendResource(value);
			gameObject.SetActive(false);
		}	
	}

	// Set functions

	public void SetBurstDirection(Vector3 dir)
	{
		burstDirection = dir;
	}

	public void SetBurstSpeed(float speed)
	{
		burstSpeed = speed;
	}

	public void SetConstructionHandler(ConstructionHandler ch)
	{
		constructionHandler = ch;
	}
}
