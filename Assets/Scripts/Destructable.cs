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
	public float activateDistance = 3.0f;
	public ConstructionHandler constructionHandler;

	public int numberMaxAmount;
	public int numberMinAmount;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Interact(RaycastHit hit, float time){
		if((Time.time - time) > holdTime){

			if(Vector3.Distance(hugo.position, transform.position) < activateDistance){
				int amount = Random.Range(numberMinAmount, numberMaxAmount);
				int rnd;


				for(int i = 0; i < amount; i++){
					if(i >= numbers.Length){
						rnd = Random.Range(0, numbers.Length);
						InstantiateNumber(rnd, hit.point);
					} else {
						InstantiateNumber(i, hit.point);
					}
				}


				transform.gameObject.GetComponent<Collider> ().enabled = false;
				transform.gameObject.GetComponent<Renderer> ().enabled = false;
			}
		}
	}

	public void InstantiateNumber(int numberID, Vector3 position){
		Number g;
		Vector3 rndVec;
		g = Instantiate(numbers[numberID], position, Quaternion.identity).GetComponent<Number>();

		g.SetConstructionHandler(constructionHandler);

		rndVec = new Vector3(Random.Range(-1,1),Random.Range(0,1),Random.Range(-1,1));
		g.SetBurstDirection(rndVec.normalized);
		g.SetBurstSpeed(Random.Range(minimumSpeed, maximumSpeed));
		g.Burst();
	}
}
