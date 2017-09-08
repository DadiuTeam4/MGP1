﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Destructable : MonoBehaviour, Holdable 
{
	public float holdTime;
	public float minimumSpeed;
	public float maximumSpeed;
	// Array of spawnable number prefabs
	public GameObject[] numbers;
	public Transform hugo;
	public ConstructionHandler constructionHandler;

	public int numberMaxAmount;
	public int numberMinAmount;

	private float timeAtFirstTrigger = 0.0f;
	private bool hasBeenSetToDestroy;

	public bool Interact(RaycastHit hit, float time)
	{
		if (!hasBeenSetToDestroy)
		{
			timeAtFirstTrigger = time;
			hasBeenSetToDestroy = true;
		}

		if ((Time.time - timeAtFirstTrigger) > holdTime)
		{
			int amount = Random.Range(numberMinAmount, numberMaxAmount);
			int rnd;

			for(int i = 0; i < amount; i++)
			{
				if (i >= numbers.Length)
				{
					rnd = Random.Range(0, numbers.Length);
					InstantiateNumber(rnd, hit.point);
				} 
				else 
				{
					InstantiateNumber(i, hit.point);
				}
			}

			transform.gameObject.GetComponent<Collider>().enabled = false;
			transform.gameObject.GetComponent<Renderer>().enabled = false;
			transform.gameObject.GetComponent<NavMeshObstacle>().enabled = false;

			Debug.Log(Time.time - timeAtFirstTrigger);
			return true;
		}

		return false;
	}

	public void InstantiateNumber(int numberID, Vector3 position)
	{
		Number g;
		Vector3 rndVec;
		g = Instantiate(numbers[numberID], position, Quaternion.identity).GetComponent<Number>();

		g.SetConstructionHandler(constructionHandler);

		rndVec = new Vector3(Random.Range(-1,1),Random.Range(0,1),Random.Range(-1,1));
		g.SetBurstDirection(rndVec.normalized);
		g.SetBurstSpeed(Random.Range(minimumSpeed, maximumSpeed));
		g.Burst();
	}

	public void SetHasBeenSetToDestroy(bool b)
	{
		hasBeenSetToDestroy = b;
	}

    public bool GetHasBeenSetToDestroy()
    {
        return hasBeenSetToDestroy;
    }

    public void TouchEnded(){
		hasBeenSetToDestroy = false;
	}

    public float GetTimeAtFirstTrigger()
    {
        return timeAtFirstTrigger;
    }
}
