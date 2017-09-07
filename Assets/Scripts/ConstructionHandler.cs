using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ConstructionHandler : MonoBehaviour {
	public GameObject[] ones, twos, threes, fours, fives;

	public BridgeController bridgeController;
	public void SendResource(int value){
		int rnd;
		switch(value){
			case 1:
				rnd = Random.Range(0, ones.Length);
				ones[rnd].GetComponent<Constructable>().Construct();
			break;

			case 2:
				rnd = Random.Range(0, twos.Length);
				twos[rnd].GetComponent<Constructable>().Construct();
			break;
			
			case 3:
				rnd = Random.Range(0, threes.Length);
				threes[rnd].GetComponent<Constructable>().Construct();
			break;
			
			case 4:
				rnd = Random.Range(0, fours.Length);
				fours[rnd].GetComponent<Constructable>().Construct();
			break;
			
			case 5:
				rnd = Random.Range(0, fives.Length);
				fives[rnd].GetComponent<Constructable>().Construct();
			break;
			
			default:
				Debug.Log("THIS VALUE IS NOT A VALID CONSTRUCTION VALUE: " + value);
			break;
		}

	}
}
