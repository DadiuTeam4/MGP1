using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour, Holdable {
	public float holdTime;
	public float minimumSpeed;
	public float maximumSpeed;
	// Array of spawnable number prefabs
	public GameObject[] numbers;
	public Transform hugo;
	private float activateDistance = 3.0f;
	public ConstructionHandler constructionHandler;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Interact(RaycastHit hit, float time){
		Debug.Log(time);
		if((Time.time - time) > holdTime){
			if (Vector3.Distance (hugo.position, transform.position) < activateDistance) {
				int amount = Random.Range (3, 10);
				int rnd;
				
				Vector3 rndVec;

				Number g;

				for (int i = 0; i < amount; i++) {
					rnd = Random.Range (0, numbers.Length);
					g = Instantiate (numbers [rnd], hit.point, Quaternion.identity).GetComponent<Number> ();

					g.SetConstructionHandler (constructionHandler);

					rndVec = new Vector3 (Random.Range (-1, 1), Random.Range (0, 1), Random.Range (-1, 1));
					g.SetBurstDirection (rndVec.normalized);
					g.SetBurstSpeed (Random.Range (minimumSpeed, maximumSpeed));
					g.Burst ();
				}


				transform.gameObject.GetComponent<Collider> ().enabled = false;
				transform.gameObject.GetComponent<Renderer> ().enabled = false;
			}
		}
	}
}
