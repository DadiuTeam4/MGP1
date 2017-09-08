using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rhythmic : MonoBehaviour 
{
	public int interval;
	public int delay;
    public bool active = false;
    public int position;
    private int currentBeat;
    
	void Start() 
	{
		currentBeat = 0 - delay;
	}
	public void IncrementCurrentBeat() 
	{
		// Increments the beat for this object
		currentBeat++;
		print(currentBeat);
        gameObject.GetComponent<Renderer>().material.color = Color.white;

        if (currentBeat >= 0 && currentBeat % interval == 0) 
		{
            active = true;
			Interact();
		}
	}


    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && active)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 10f))
                Debug.DrawRay(ray.origin, hit.point);

            //Destroy(gameObject);
            
            Destroy(GameObject.Find(hit.collider.gameObject.name));
        }
    }


    //return everything to a non active state
    public void InitialState()
    {
        active = false;
        gameObject.GetComponent<Renderer>().material.color = Color.white;
    }


    // Abstract function to override
    protected virtual void Interact() {}
}
