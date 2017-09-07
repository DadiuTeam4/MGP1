using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchHandler : MonoBehaviour {
	private List<float> touchTimes = new List<float>();

	// Computer debugging Variables:
	public bool testingOnComputer;
	public float timeStamp;

	void Update () 
	{
		if(testingOnComputer){
			Ray ray;
			RaycastHit hit;

			if(Input.GetMouseButtonDown(0)){
				ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				timeStamp = Time.time;

				if(Physics.Raycast(ray, out hit)){
					if(hit.collider.gameObject.tag == "Touchable"){
						Touchable obj = hit.collider.gameObject.GetComponent<Touchable>();
						obj.Interact(hit);
					}
				}
			}

			if(Input.GetMouseButton(0)){
				ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				
				if(Physics.Raycast(ray, out hit)){
					if(hit.collider.gameObject.tag == "Holdable"){
						Holdable obj = hit.collider.gameObject.GetComponent<Holdable>();
						obj.Interact(hit, timeStamp);
					}
				}
			}
		}
		else
		{
			int touchCount = Input.touchCount;
			if (touchCount == 0) 
			{
				return;
			}
			else 
			{
				// Touch Part
				for (int i = 0; i < touchCount; i++)
				{
					Touch touch = Input.GetTouch(i);
					Vector2 position = touch.position;
					Ray ray;
					RaycastHit hit;

					switch(touch.phase){
						case TouchPhase.Began:
							touchTimes.Add(Time.time);
							ray = Camera.main.ScreenPointToRay(new Vector3(touch.position.x, touch.position.y, 0));
							if (Physics.Raycast(ray, out hit)) 
							{
								if (hit.collider.gameObject.tag == "Touchable") 
								{
									Touchable obj = hit.collider.gameObject.GetComponent<Touchable>();
									obj.Interact(hit);
								}
							}
						break;

						case TouchPhase.Ended:
							ray = Camera.main.ScreenPointToRay(new Vector3(touch.position.x, touch.position.y, 0));
							if (Physics.Raycast(ray, out hit)) 
							{
								if (hit.collider.gameObject.tag == "Holdable") 
								{
									Holdable obj = hit.collider.gameObject.GetComponent<Holdable>();
									obj.TouchEnded();
								}
							}

							touchTimes.RemoveAt(i);
						break;
					}

					if(touch.phase != TouchPhase.Ended){
						bool done = false;
						ray = Camera.main.ScreenPointToRay(new Vector3(touch.position.x, touch.position.y, 0));
						if (Physics.Raycast(ray, out hit)) 
						{
							if (hit.collider.gameObject.tag == "Holdable") 
							{
								Holdable obj = hit.collider.gameObject.GetComponent<Holdable>();
								done = obj.Interact(hit, touchTimes[i]);
							}
						}
						if(done){
							touchTimes.RemoveAt(i);
						}
					}
				}
			}
		}
	}
}
