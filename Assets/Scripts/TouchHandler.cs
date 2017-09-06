using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchHandler : MonoBehaviour {

	// Debug mode for computer testing, since touch doesnt work with a mouse
	public bool debug;

	void Start(){

	}

	void Update () 
	{
		int touchCount = Input.touchCount;
		if (touchCount == 0 && !debug) 
		{
			return;
		}
		else 
		{
			if(debug){
				if(Input.GetMouseButtonDown(0)){
					Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
					RaycastHit hit;
					if (Physics.Raycast(ray, out hit)) 
					{
						if (hit.collider.gameObject.tag == "Touchable") 
						{
							Touchable obj = hit.collider.gameObject.GetComponent<Touchable>();
							obj.Interact(hit);
						}
					}
				}
			}

			// Touch Part
			for (int i = 0; i < touchCount; i++)
			{
				Touch touch = Input.GetTouch(i);
				Vector2 position = touch.position;
				Ray ray = Camera.main.ScreenPointToRay(new Vector3(touch.position.x, touch.position.y, 0));
				RaycastHit hit;
				if (Physics.Raycast(ray, out hit)) 
				{
					if (hit.collider.gameObject.tag == "Touchable") 
					{
						Touchable obj = hit.collider.gameObject.GetComponent<Touchable>();
						obj.Interact(hit);
					}
				}
			}
		}
	}
}
