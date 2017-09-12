// Author: Itai Yavin
// Contributor:

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ConstructionHandler : MonoBehaviour {
	[Tooltip("Each array needs to be filled with the corresponding CONSTRUCTABLES that you want to react to the number. Fx. all constructables that you want to react on pickup of ones, put in the ones array. IF AN ARRAY IS EMPTY IT WILL MAKE IT IMPOSSIBLE TO PICK UP NUMBERS")]
	public GameObject[] ones, twos, threes, fours, fives;

	
	// Calls the construct function of the necessary constructable, depending on the value given through the function.
	// The object chosen from the array is random.
	public void SendResource(int value){
		int rnd;
		switch(value){
		case 1:
			rnd = Random.Range (0, ones.Length);
			ones [rnd].GetComponent<Constructable> ().Construct ();
			AkSoundEngine.PostEvent ("Env_build", gameObject); 
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
