// Author: Itai Yavin
// Contributor:

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Resurrect : MonoBehaviour {

	[Tooltip("Amount of seconds till item reappears")]
	public float resurrectTime;
	
	[Tooltip("Amount scaled per frame")]
	[Range(0.01f, 1.0f)]
	public float scaleStep;
	
	private Vector3 normalScale;
	private float timestamp; // Timestamp for when reappearence
	private Collider col;
	private Renderer ren;
	private NavMeshObstacle navMeshObs;
	private bool resurrecting = false;

	private Destructable des;

	// Use this for initialization
	void Start () 
	{
		des = gameObject.GetComponent<Destructable>();
		col = gameObject.GetComponent<Collider>();
		ren = gameObject.GetComponent<Renderer>();
		navMeshObs = gameObject.GetComponent<NavMeshObstacle>();
		normalScale = gameObject.transform.localScale;
	}
	
	// Update is called once per frame
	void Update () 
	{
		// The deconstruction script disables the collider on deconstruction
		// So the resurrection script looks for a disabled collider to check whether the object as been deconstructed
		// It also sets the timestamp for when resurrection should happen
		if(!col.enabled && !resurrecting) 
		{
			timestamp = Time.time + resurrectTime;
			resurrecting = true;
		}

		// Upon resurrection the collider, renderer and navMeshObstacle (which are all disabled on deconstruction) are enabled
		// A boolean within the deconstructor is also set to false. This bool is used within the deconstructor to determine
		// Whether the object is set for deconstruction
		if(Time.time > timestamp && resurrecting)
		{
			col.enabled = true;
			ren.enabled = true;
			navMeshObs.enabled = true;
			des.SetHasBeenSetToDestroy(false);
			resurrecting = false;
			if(des.hasParticles)
			{
				des.GetComponent<ParticleSystem>().Play();
			}

			StartCoroutine("ScaleThroughTime");
		}
	}

	IEnumerator ScaleThroughTime(){
		Vector3 miniScale = new Vector3(normalScale.x * 0.1f, normalScale.x * 0.1f, normalScale.x * 0.1f);
		float t = 0.0f;


		while(t != 1.0f){
			t += scaleStep;
			if(t > 1.0f)
			{
				t = 1.0f;
			}

			gameObject.transform.localScale = Vector3.Lerp(miniScale, normalScale, t);
			yield return null;
		}
	}
}
