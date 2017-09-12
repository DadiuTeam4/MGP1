// Author: Mathias Hedelund
// Contributor: Itai Yavin

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchHandler : MonoBehaviour
{
	// This list should contain as many floats as there are touches
	// The list is meant to record the time that each touch started.
    private List<float> touchTimes = new List<float>();

    // Computer debugging Variables:
    public bool testingOnComputer = false; // ENABLES MOUSE INPUT - DISABLES TOUCH INPUT
    public float timeStamp; // Time at mouse click, used for mouse input.
    public bool isInputEnabled = true;

	private int layerMask = ~(1 << 9); // Ignored raycast layers
	private Holdable lastHoldable;

    void Update()
    {
        if (!isInputEnabled)
        {
            return;
        }

		#region PC Debugging
		// Only for debugging on pc
		// Should be disabled by default as it will deny touch input
        if(testingOnComputer)
		{
			Ray ray;
			RaycastHit hit;

			if(Input.GetMouseButtonDown(0))
			{
				ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				timeStamp = Time.time;

				if(Physics.Raycast(ray, out hit, 100, layerMask))
				{
					if(hit.collider.gameObject.tag == "Touchable")
					{
						Touchable obj = hit.collider.gameObject.GetComponent<Touchable>();
						obj.Interact(hit);
				
					}
				}
			}

			if(Input.GetMouseButton(0))
			{
				ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				
				if(Physics.Raycast(ray, out hit, 100, layerMask))
				{
					if(hit.collider.gameObject.tag == "Holdable")
					{
						Holdable obj = hit.collider.gameObject.GetComponent<Holdable>();
						obj.Interact(hit, timeStamp);
					}
					
					if (hit.collider.gameObject.tag == "Touchable") 
					{
						Touchable obj = hit.collider.gameObject.GetComponent<Touchable>();
						obj.Interact(hit);
					}
				}
			}

			if(Input.GetMouseButtonUp(0))
			{
				ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				
				if(Physics.Raycast(ray, out hit, 100, layerMask))
				{
					if(hit.collider.gameObject.tag == "Holdable")
					{
						Holdable obj = hit.collider.gameObject.GetComponent<Holdable>();
						obj.TouchEnded();
					}
				}
			}
		}
		#endregion
		// Touch input
		else
		{
			int touchCount = Input.touchCount;
			if (touchCount == 0) 
			{
				return;
			}
			else 
			{
				// Loops through all touch inputs (1 per finger)
				for (int i = 0; i < touchCount; i++)
				{
					Touch touch = Input.GetTouch(i);
					Ray ray;
					RaycastHit hit;

					// A Unity Touch goes through several phases through its lifetime
					// TouchPhase.Began 		- On touch beginning
					// TouchPhase.Stationaty 	- Finger has not moved since last check
					// TouchPhase.Moved 		- Finger moved since last check
					// TouchPhase.Ended			- On touch end
					switch(touch.phase){
						// If the touch input started this frame
						case TouchPhase.Began:
							touchTimes.Add(Time.time);
							ray = Camera.main.ScreenPointToRay(new Vector3(touch.position.x, touch.position.y, 0));
							if (Physics.Raycast(ray, out hit, 100, layerMask)) 
							{
								if (hit.collider.gameObject.tag == "Touchable") 
								{
									Touchable obj = hit.collider.gameObject.GetComponent<Touchable>();
									obj.Interact(hit);
								}
							}
							break;

						// If the touch input did not move since last frame
						case TouchPhase.Stationary:
							break;

						// If the touch input did move since last frame
						case TouchPhase.Moved:
							touchTimes[i] = Time.time;
							ray = Camera.main.ScreenPointToRay(new Vector3(touch.position.x, touch.position.y, 0));
							if (Physics.Raycast(ray, out hit, 100, layerMask)) 
							{
								if (hit.collider.gameObject.tag == "Holdable") 
								{
									// Check that the touch input is still hitting the same holdable object
									Holdable obj = hit.collider.gameObject.GetComponent<Holdable>();
									if (obj != lastHoldable && lastHoldable != null)
									{
										lastHoldable.TouchEnded();
									}
								}
								else if (lastHoldable != null) 
								{
									lastHoldable.TouchEnded();
								}
							}
							break;

						// If the touch input ended this frame
						case TouchPhase.Ended:
							ray = Camera.main.ScreenPointToRay(new Vector3(touch.position.x, touch.position.y, 0));
							if (Physics.Raycast(ray, out hit, 100, layerMask)) 
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

					// This was added to check raycast between touch phases, whether the touch is moving or not.
					// This could possibly be removed and implemented into the Switch Case.
					if(touch.phase != TouchPhase.Ended)
					{
						bool done = false;
						ray = Camera.main.ScreenPointToRay(new Vector3(touch.position.x, touch.position.y, 0));
						if (Physics.Raycast(ray, out hit, 100, layerMask)) 
						{
							if (hit.collider.gameObject.tag == "Holdable") 
							{
								Holdable obj = hit.collider.gameObject.GetComponent<Holdable>();
								done = obj.Interact(hit, touchTimes[i]);
								lastHoldable = obj;
							}
						}
						/*if (done) - This line created errors since an entry could end up triggering two removes, thus triggering an "Array Index is Out of Bounds" error.
						{
							touchTimes.RemoveAt(i); 
						}*/
					}
				}
			}
		}

    }
}
