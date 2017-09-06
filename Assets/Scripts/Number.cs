using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Number : MonoBehaviour {

	private Vector3 burstDirection;
	private float burstSpeed;
	public Rigidbody rig;

	public void SetBurstDiretion(Vector3 dir){
		burstDirection = dir;
	}

	public void SetBurstSpeed(float speed){
		burstSpeed = speed;
	}

	public void Burst(){
		rig.AddForce(burstDirection * burstSpeed);
	}
}
