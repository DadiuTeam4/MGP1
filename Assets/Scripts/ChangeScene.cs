using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {

	public string sceneName;
	public float delay;

	void OnTriggerEnter(Collider other) {
		if (other.transform.tag == "Player") {
			StartCoroutine ("ChangeTheScene");
		}
	}

	IEnumerator ChangeTheScene() {
		yield return new WaitForSeconds (delay);
		SceneManager.LoadScene (sceneName);
		//AkSoundEngine.PostEvent ("transition"); 
	}
}
