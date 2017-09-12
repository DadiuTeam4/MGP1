// Author: Mathias Dam Hedelund

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransition : MonoBehaviour {
	public float speed;
	public GameObject transitionObject;
	public Transform startPos;
	public Transform endPos;
	public float delayBeforeLoadingNewScene;
	public bool dontDestroyOnLoad;
	private float timeToEnd;
	private float timer;
	private bool moving;
	private string newLevel;

	void Start() 
	{
		timeToEnd = 100 / speed;
		if (dontDestroyOnLoad) 
		{
			DontDestroyOnLoad(transitionObject);
		}
	}

	void FixedUpdate() 
	{
		if (moving) 
		{
			timer += Time.deltaTime;
			float progress = timer / timeToEnd;
			Vector3 pos = Vector3.Lerp(startPos.position, endPos.position, progress);
			transitionObject.transform.position = pos;
			if (progress > 1.0f) 
			{
				StartCoroutine(ChangeScene(delayBeforeLoadingNewScene));
			}
		}
	}

	public void StartTransition(string level) 
	{
		newLevel = level;
		moving = true;
	}

	IEnumerator ChangeScene(float seconds) 
	{
		yield return new WaitForSeconds(seconds);
		SceneManager.LoadScene(newLevel);
	}
}
