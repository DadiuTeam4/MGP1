using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Number : MonoBehaviour {
	public int value;
	private Vector3 burstDirection;
	private float burstSpeed;
	public Rigidbody rig;
	private ConstructionHandler constructionHandler;

	public void SetBurstDirection(Vector3 dir){
		burstDirection = dir;
	}

	public void SetBurstSpeed(float speed){
		burstSpeed = speed;
	}

	public void Burst(){
		rig.AddForce(burstDirection * burstSpeed);
	}

	public void SetConstructionHandler(ConstructionHandler ch){
		constructionHandler = ch;
	}
	void OnTriggerEnter(Collider other)
	{
		if(other.transform.tag == "Player"){
			constructionHandler.SendResource(value);
			
			gameObject.SetActive(false);
		}	
	}
}
