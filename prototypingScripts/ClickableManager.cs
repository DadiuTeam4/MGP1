using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableManager : MonoBehaviour {
	public Moving[] clickables;
	public float spawningCooldown;
	
	private float timer;

	// Use this for initialization
	void Start () {
		timer = Time.time + spawningCooldown;
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time > timer){
			Moving temp = FindUsableCube();

			if(temp != null){
				SpawnClickable(temp);
			}

			timer = Time.time + spawningCooldown;
		}
	}

	public Moving FindUsableCube(){
		for(int i = 0; i < clickables.Length; i++){
			if(!clickables[i].gameObject.activeSelf){
				return clickables[i];
			}
		}
		return null;
	}

	public void SpawnClickable(Moving cube){
		cube.rig.velocity = Vector3.zero;
		
		int rndHealth = Random.Range(1, 5);
		int rndm = Random.Range(1, 5);
		Vector3 rndmVec = new Vector3(Random.Range(-5, 5), Random.Range(-5, 5), Random.Range(-5, -1));
		rndmVec.Normalize();

		Vector3 rndmPos = new Vector3(Random.Range(-5, 5), Random.Range(-5, 5), 10);

		cube.gameObject.SetActive(true);
		cube.rig.useGravity = false;
		cube.gameObject.transform.position = rndmPos;
		cube.direction = rndmVec;
		cube.health = rndHealth;
		cube.transform.GetComponent<Renderer>().material.color = new Color(1,1,1,1);
		cube.startHealth = rndHealth;
		cube.colorT = 0;
		cube.speed = rndm;
		cube.dragable = false;
		cube.lockMouse = false;
	}
}