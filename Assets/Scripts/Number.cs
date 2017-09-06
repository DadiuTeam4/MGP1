using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Number : MonoBehaviour, Touchable {
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

	public void Interact(RaycastHit hit){
		constructionHandler.SendResource(value);
		
		gameObject.SetActive(false);
	}

	public void SetConstructionHandler(ConstructionHandler ch){
		constructionHandler = ch;
	}
}
