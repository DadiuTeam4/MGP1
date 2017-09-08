using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Number : MonoBehaviour, Touchable
{
	public int value;
	public Rigidbody rig;
	public float WalkToDistance = 1.0f;

	private Vector3 burstDirection;
	private float burstSpeed;
	private ConstructionHandler constructionHandler;
	private PlayerAI hugo;

	void Start() 
	{
		hugo = FindObjectOfType<PlayerAI>();	
	}

	public void SetBurstDirection(Vector3 dir)
	{
		burstDirection = dir;
	}

	public void SetBurstSpeed(float speed)
	{
		burstSpeed = speed;
	}

	public void Burst()
	{
		rig.AddForce(burstDirection * burstSpeed);
	}

	public void SetConstructionHandler(ConstructionHandler ch)
	{
		constructionHandler = ch;
	}
	void OnTriggerEnter(Collider other)
	{
		if(other.transform.tag == "Player")
		{
			constructionHandler.SendResource(value);
			gameObject.SetActive(false);
		}	
	}

	public void Interact(RaycastHit hit) 
	{
		print("Clicked number");
		if (Vector3.Distance(hugo.transform.position, transform.transform.position) > WalkToDistance)
		{
			hugo.playerAI.SetDestination(hit.point);
		}
	}
}
