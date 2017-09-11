using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Resurrect : MonoBehaviour {

	public float resurrectTime;
	
	private float timestamp;
	private Collider col;
	private Renderer ren;
	private NavMeshObstacle navMeshObs;
	private bool resurrecting = false;

	private Destructable des;

	// Use this for initialization
	void Start () {
		des = gameObject.GetComponent<Destructable>();
		col = gameObject.GetComponent<Collider>();
		ren = gameObject.GetComponent<Renderer>();
		navMeshObs = gameObject.GetComponent<NavMeshObstacle>();
	}
	
	// Update is called once per frame
	void Update () {
		if(!col.enabled && !resurrecting){
			timestamp = Time.time + resurrectTime;
			resurrecting = true;
		}

		if(Time.time > timestamp && resurrecting){
			col.enabled = true;
			ren.enabled = true;
			navMeshObs.enabled = true;
			des.SetHasBeenSetToDestroy(false);
			resurrecting = false;
		}
	}
}
