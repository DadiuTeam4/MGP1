using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelFade : MonoBehaviour 
{

	public Image image;
	public float fadeTime;
	public string nextScene;

	void Start() 
	{
		image.CrossFadeColor(new Color(1, 1, 1, 0), fadeTime, true, true);
	}

	public void FadeIn(string nextScene) 
	{
		StartCoroutine(fadeIn(nextScene));
	}

	IEnumerator fadeIn(string nextLevel)
	{
		image.CrossFadeColor(new Color(1, 1, 1, 1), fadeTime, true, true);
		yield return new WaitForSeconds(fadeTime);
		SceneManager.LoadScene(nextLevel);
	}

}
