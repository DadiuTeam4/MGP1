using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OpenSceneController : MonoBehaviour
{

    // Use this for initialization



    public string nextScene;
    public bool danish;
    public Transform danishTransform;
    public bool english;
    public Transform englishTransform;
    public Transform StartBTN;
    public Transform Hugo; 


    // Update is called once per frame
    void Update()
    {
	/*	//Touchcount for tablet, anykeydown for mouse/unity test interface
		if (Input.touchCount > 0 ||Input.anyKeyDown)
        {
			SceneManager.LoadScene(nextScene, LoadSceneMode.Single);

        }
        */
    }

    public void StartGame()
    {
        SceneManager.LoadScene(nextScene, LoadSceneMode.Single);
    }

    public void Danish()
    {   
        danish = true;
        danishTransform.gameObject.SetActive(false);
        englishTransform.gameObject.SetActive(false);
        StartBTN.gameObject.SetActive(true);

    }

    public void English()
    {
        english = true;
        danishTransform.gameObject.SetActive(false);
        englishTransform.gameObject.SetActive(false);
        StartBTN.gameObject.SetActive(true);
    }

    void MoveHugo()
    {

    }
}
