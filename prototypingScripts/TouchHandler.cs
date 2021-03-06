﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchHandler : MonoBehaviour {
	public Text text;
	void Update () 
	{
		int touchCount = Input.touchCount;
		bool mouseClicked = Input.GetMouseButtonDown(0);
		if (touchCount == 0 && !mouseClicked) 
		{
			return;
		}
		else 
		{
			int clicks = touchCount != 0 ? touchCount : Input.GetMouseButtonDown(0) ? 1 : 0;
			text.text = touchCount.ToString();

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
						obj.Interact();
					}
				}
			}
		}
	}
}
