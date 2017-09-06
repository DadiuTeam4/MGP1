using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour {

	// Use this for initialization
	public int score = 0;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;

			if (Physics.Raycast(ray, out hit, 100))
			{
				Debug.DrawLine(ray.origin, hit.point);
			}

			if(hit.transform != null){
				if(hit.transform.tag == "Clickable")
				{
					Moving temp;
					temp = hit.transform.GetComponent<Moving>();

					if(!temp.dragable){
						temp.health--;

						if(temp.health == 0){
							score++;
						}

						temp.colorT += 1.0f/(float)temp.startHealth;

						Debug.Log(temp.colorT);

						hit.transform.GetComponent<Renderer>().material.color = new Color(1, 1-temp.colorT, 1-temp.colorT, 1);
					}
					else{
						if(Input.GetMouseButtonDown(0)){
							//temp.rig.velocity = Vector3.zero;
							temp.lockMouse = true;
						}
					}
				}
			}
		}
	}
}
