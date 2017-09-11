using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resurrect : MonoBehaviour {

	public float resurrectTime;

	private float timestamp;
	private Collider col;
	private Renderer ren;
	private bool resurrecting = false;

	// Use this for initialization
	void Start () {
		col = gameObject.GetComponent<Collider>();
		ren = gameObject.GetComponent<Renderer>();
	}

	// Update is called once per frame
	void Update () {
		if(!col.enabled && !resurrecting){
			timestamp = Time.time + resurrectTime;
			resurrecting = true;
		}

		if(Time.time > timestamp){
			col.enabled = true;
			ren.enabled = true;
			resurrecting = false;
		}
	}
}