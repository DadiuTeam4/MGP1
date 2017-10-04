using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour {
	public int health;
	public int startHealth;

	public float colorT;
	public float speed;
	public Vector3 direction;

	public bool dragable = false;
	public bool lockMouse = false;

	public Rigidbody rig;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(health == 0){
			dragable = true;
		}

		if(lockMouse){
			rig.useGravity = true;
			//LockToMouse();
		}
		if(rig.velocity.magnitude < speed){
			rig.AddForce(direction*speed);
		}

		if(transform.position.z < -10 || transform.position.y < -10){
			gameObject.SetActive(false);
		}

	}

	public void LockToMouse(){
		Vector3 temp = new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z);
		transform.position = Camera.main.ScreenToWorldPoint(new Vector3(temp.x, temp.y, transform.position.z));
	}
}
