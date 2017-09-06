using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchHandler : MonoBehaviour {
	private List<float> touchTimes = new List<float>();

	void Update () 
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
								obj.Interact(hit, touchTimes[i]);
							}
						}

						touchTimes.RemoveAt(i);
					break;
				}
			}
		}
	}
}
