// Author: Itai Yavin
// Contributor:

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Destructable : MonoBehaviour, Holdable 
{
	[Tooltip("The length of time, of a touch for deconstruction. In seconds")]
	public float holdTime;

	[Header("Random Ranges")]
	[Tooltip("The minimum random speed for which numbers are given")]
	public float minimumSpeed;
	[Tooltip("The maximum random speed for which numbers are given")]
	public float maximumSpeed;
	[Tooltip("The minimum random amount of numbers spawned")]
	public int numberMaxAmount;
	[Tooltip("The maximum random amount of numbers spawned")]
	public int numberMinAmount;

	[Header("Prefab and object references")]
	public GameObject[] numbers;
	public Transform hugo;
	public ConstructionHandler constructionHandler;

	private float timeAtFirstTrigger = 0.0f; // Time at first touch
	private bool hasBeenSetToDestroy;


	//Hack to get scenechange on whale destruction
	public bool changeSceneOnDestroyed;
	public string sceneName;
	public float delay;

	IEnumerator ChangeTheScene() {
		yield return new WaitForSeconds (delay);
		SceneManager.LoadScene (sceneName);
	}

	// Keeps track on whether the object is set for destruction, and how long it has been since first touch.
	// Upon deconstruction it spawns a random amount of numbers.
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
			if (transform.childCount > 0) 
			{
				Renderer r;
				for (int i = 0; i < transform.childCount; i++) 
				{
					r = transform.GetChild (i).GetComponent<Renderer> ();
					if (r != null) 
					{
						r.enabled = false;
					}
				}
			} else 
			{
				transform.gameObject.GetComponent<Renderer>().enabled = false;
			}
			if (transform.gameObject.GetComponent<NavMeshObstacle>() != null) {
				transform.gameObject.GetComponent<NavMeshObstacle>().enabled = false;
			}

			if (changeSceneOnDestroyed) 
			{
				GetComponent<LevelTransition>().StartTransition(sceneName);
			}
			return true;
		}

		return false;
	}

	// Instantiates a number and set its direction and speed to random values.
	// Lastly it also calls the number burst function - See number class for description.
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

    public void TouchEnded(){
		hasBeenSetToDestroy = false;
	}

	// Set functions
	public void SetHasBeenSetToDestroy(bool b)
	{
		hasBeenSetToDestroy = b;
	}

	// Get Functions
    public bool GetHasBeenSetToDestroy()
    {
        return hasBeenSetToDestroy;
    }

    public float GetTimeAtFirstTrigger()
    {
        return timeAtFirstTrigger;
    }
}
