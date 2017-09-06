using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constructable : MonoBehaviour {

	public int value;

	public void Construct(){
		switch(value){
			case 1:
				ChangeScale(new Vector3(0.1f, 0.0f, 0.05f));
			break;
			
			case 2:
				ChangeColour(new Color(0.1f, 0.0f, 0.2f));
			break;
			
			case 3:
				ChangeColour(new Color(0.0f, 0.0f, 0.2f));
			break;
			
			case 4:
				ChangeScale(new Vector3(0.0f, 0.03f, 0.0f));
			break;

			case 5:
				ChangeColour(new Color(0.0f, 0.3f, 0.0f));
			break;
		}
	}

	private void ChangeColour(Color col){
		gameObject.GetComponent<Renderer>().material.color -= col;
	}


	private void ChangeScale(Vector3 change){
		transform.localScale += change;
	}
}
